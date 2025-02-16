import { ChangeDetectorRef, Component, Injector, OnInit, ViewChild } from "@angular/core";
import { MemberServiceProxy, MemberOutputDto } from "../../shared/service-proxies/service-proxies";
import { Table } from "primeng/table";
import { Paginator } from "primeng/paginator";
import { LazyLoadEvent } from "primeng/api";
import { PagedListingComponentBase } from "../../shared/paged-listing-component-base";
import { finalize } from "rxjs/operators";
import { appModuleAnimation } from "@shared/animations/routerTransition";
import { BsModalService, BsModalRef } from "ngx-bootstrap/modal";
import { MemberEntryComponent } from "./member-entry/member-entry.component";

@Component({
  selector: 'app-embers',
  templateUrl: './members.component.html',
  animations: [appModuleAnimation()],
})

export class MembersComponent extends PagedListingComponentBase<MemberOutputDto> {

  @ViewChild("dataTable", { static: true }) dataTable: Table;
  @ViewChild("paginator", { static: true }) paginator: Paginator;

  searchText: string = "";

  constructor(
    injector: Injector,
    private readonly _memberService: MemberServiceProxy,
    private readonly _modalService: BsModalService,
    cd: ChangeDetectorRef
  ) {
    super(injector, cd);
  }


  list(event?: LazyLoadEvent): void {
    if (this.primengTableHelper.shouldResetPaging(event)) {
      this.paginator.changePage(0);

      if (
        this.primengTableHelper.records &&
        this.primengTableHelper.records.length > 0
      ) {
        return;
      }
    }

    this.primengTableHelper.showLoadingIndicator();
    this._memberService.getPaginatedMembers(
      "",
      this.primengTableHelper.getSkipCount(this.paginator, event),
      this.primengTableHelper.getMaxResultCount(this.paginator, event)
    ).pipe(
      finalize(() => {
        this.primengTableHelper.hideLoadingIndicator();
      })
    )
      .subscribe((result) => {
        this.primengTableHelper.records = result.items;
        this.primengTableHelper.totalRecordsCount = result.totalCount;
        this.primengTableHelper.hideLoadingIndicator();
        this.cd.detectChanges();
      });


  }

  createMember() {
    this.showMemberEntryDialog();
  }

  editMember(member: MemberOutputDto) {

  }

  delete(user: MemberOutputDto): void {
    //   abp.message.confirm(
    //     this.l("UserDeleteWarningMessage", user.fullName),
    //     undefined,
    //     (result: boolean) => {
    //       if (result) {
    //         this._userService.delete(user.id).subscribe(() => {
    //           abp.notify.success(this.l("SuccessfullyDeleted"));
    //           this.refresh();
    //         });
    //       }
    //     }
    //   );
  }

  private showMemberEntryDialog(id?: number): void {
    let memberEntryDialog: BsModalRef;
    memberEntryDialog = this._modalService.show(
      MemberEntryComponent,
      {
        class: "modal-lg",
        initialState: {
          id: id,
        },
      }
    );
    memberEntryDialog.content.onSave.subscribe(() => {
      this.refresh();
    });
  }

}
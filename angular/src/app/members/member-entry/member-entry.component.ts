import { Component, EventEmitter, OnInit, Output } from "@angular/core";
import { MemberEntryDto } from "@shared/service-proxies/service-proxies";
import { BsModalRef } from 'ngx-bootstrap/modal';

@Component({
    selector: 'app-member-entry',
    templateUrl: './member-entry.component.html'
})

export class MemberEntryComponent implements OnInit {

    @Output() onSave = new EventEmitter<any>();

    member = new MemberEntryDto();
    saving = false;
    id?: number;

    constructor(
        public bsModalRef: BsModalRef,
    ) {

    }

    ngOnInit(): void {

    }

    save() {

    }
}
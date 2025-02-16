import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { MembersRoutingModule } from './members-routing.module';
import { MembersComponent } from './members.component';
import { MemberEntryComponent } from './member-entry/member-entry.component';
import { SharedModule } from '@shared/shared.module';


@NgModule({
  declarations: [
    MembersComponent,
    MemberEntryComponent
  ],
  imports: [
    SharedModule,
    CommonModule,
    MembersRoutingModule
  ]
})
export class MembersModule { }

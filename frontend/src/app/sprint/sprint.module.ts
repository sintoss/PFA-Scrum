import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import {ShowSprintComponent} from './show-sprint/show-sprint.component';
import {AddEditSprintComponent} from './add-edit-sprint/add-edit-sprint.component';
import {FormsModule} from '@angular/forms';



@NgModule({
  declarations: [
    ShowSprintComponent,
    AddEditSprintComponent
  ],
    imports: [
        CommonModule,
        FormsModule
    ],
  exports: [
    ShowSprintComponent
  ]
})
export class SprintModule { }

import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import {ShowSprintComponent} from './show-sprint/show-sprint.component';
import {AddEditSprintComponent} from './add-edit-sprint/add-edit-sprint.component';
import {FormsModule} from '@angular/forms';
import { StoryAffectionComponent } from './story-affection/story-affection.component';
import { SprintDetailComponent } from './sprint-detail/sprint-detail.component';



@NgModule({
  declarations: [
    ShowSprintComponent,
    AddEditSprintComponent,
    StoryAffectionComponent,
    SprintDetailComponent
  ],
    imports: [
        CommonModule,
        FormsModule
    ],
    exports: [
        ShowSprintComponent,
        SprintDetailComponent
    ]
})
export class SprintModule { }

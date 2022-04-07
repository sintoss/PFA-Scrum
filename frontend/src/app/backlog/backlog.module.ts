import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { BacklogItemComponent } from './backlog-item/backlog-item.component';
import {StoryListComponent} from './story-list/story-list.component';
import {FormsModule} from '@angular/forms';



@NgModule({
  declarations: [BacklogItemComponent, StoryListComponent],
  exports: [
    BacklogItemComponent,
    BacklogItemComponent
  ],
    imports: [
        CommonModule,
        FormsModule
    ]
})
export class BacklogModule { }

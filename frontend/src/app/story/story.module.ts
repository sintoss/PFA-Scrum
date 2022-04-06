import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { StoryListComponent } from './story-list/story-list.component';
import { StoryFormComponent } from './story-form/story-form.component';
import {BacklogComponent} from './story-list/backlog/backlog.component';
import {FormsModule} from '@angular/forms';



@NgModule({
  declarations: [StoryListComponent, StoryFormComponent,BacklogComponent],
  imports: [CommonModule, FormsModule],
  exports: [StoryListComponent, StoryFormComponent, BacklogComponent]
})
export class StoryModule { }

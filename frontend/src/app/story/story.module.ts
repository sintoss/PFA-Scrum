import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { StoryListComponent } from './story-list/story-list.component';
import { StoryItemComponent } from './story-item/story-item.component';
import { StoryFormComponent } from './story-form/story-form.component';



@NgModule({
  declarations: [StoryListComponent, StoryItemComponent, StoryFormComponent],
  imports: [CommonModule],
  exports: [StoryListComponent, StoryFormComponent]
})
export class StoryModule { }

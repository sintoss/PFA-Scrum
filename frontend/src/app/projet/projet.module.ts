import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { ProjetRoutingModule } from './projet-routing.module';
import { ProjetComponent } from './projet.component';
import { HeaderComponent } from '../header/header.component';
import { SubHeaderComponent } from '../sub-header/sub-header.component';
import { ProjetListComponent } from './projet-list/projet-list.component';
import { ProjetCardComponent } from './projet-card/projet-card.component';
import { ProjetDetailComponent } from './projet-detail/projet-detail.component';
import { ProjetFormComponent } from './projet-form/projet-form.component';
import { FormsModule } from '@angular/forms';
import { BacklogComponent } from '../backlog/backlog.component';
import { SprintComponent } from '../sprint/sprint.component';
import { TacheListComponent } from '../tache/tache-list/tache-list.component';
import { TacheItemComponent } from '../tache/tache-item/tache-item.component';
import { TacheFormComponent } from '../tache/tache-form/tache-form.component';
import { StoryListComponent } from '../story/story-list/story-list.component';
import { StoryItemComponent } from '../story/story-item/story-item.component';
import { StoryFormComponent } from '../story/story-form/story-form.component';


@NgModule({
  declarations: [
    ProjetComponent, 
    HeaderComponent, 
    SubHeaderComponent, 
    ProjetListComponent, 
    ProjetCardComponent, 
    ProjetDetailComponent,
    ProjetFormComponent,
    BacklogComponent,
    SprintComponent,
    TacheListComponent,
    TacheItemComponent,
    TacheFormComponent,
    StoryListComponent,
    StoryItemComponent,
    StoryFormComponent
  ],
  imports: [
    CommonModule,
    FormsModule,
    ProjetRoutingModule
  ],
  exports: [ProjetComponent]
})
export class ProjetModule { }

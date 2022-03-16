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
import { StoryModule } from '../story/story.module';
import { TacheModule } from '../tache/tache.module';


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
    SprintComponent
  ],
  imports: [
    CommonModule,
    FormsModule,
    ProjetRoutingModule,
    StoryModule,
    TacheModule
  ],
  bootstrap: [ProjetComponent]
})
export class ProjetModule { }

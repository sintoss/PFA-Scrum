import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { LoginComponent } from './login/login.component';
import { SignupComponent } from './signup/signup.component';
import { ProjetCardComponent } from './projet/projet-card/projet-card.component';
import { ProjetListComponent } from './projet/projet-list/projet-list.component';
import { ProjetDetailComponent } from './projet/projet-detail/projet-detail.component';
import { ProjetFormComponent } from './projet/projet-form/projet-form.component';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { HeaderComponent } from './header/header.component';
import { SubHeaderComponent } from './sub-header/sub-header.component';
import { BacklogComponent } from './backlog/backlog.component';
import { StoryItemComponent } from './story/story-item/story-item.component';
import { StoryListComponent } from './story/story-list/story-list.component';
import { StoryFormComponent } from './story/story-form/story-form.component';
import { TacheItemComponent } from './tache/tache-item/tache-item.component';
import { TacheListComponent } from './tache/tache-list/tache-list.component';
import { TacheFormComponent } from './tache/tache-form/tache-form.component';
import { SprintComponent } from './sprint/sprint.component';

@NgModule({
  declarations: [
    AppComponent,
    LoginComponent,
    SignupComponent,
    /*HeaderComponent,
    SubHeaderComponent,
    ProjetCardComponent,
    ProjetListComponent,
    ProjetDetailComponent,
    ProjetFormComponent,
    BacklogComponent,
    StoryItemComponent,
    StoryListComponent,
    StoryFormComponent,
    TacheItemComponent,
    TacheListComponent,
    TacheFormComponent,
    SprintComponent*/
  ],
  imports: [
    BrowserModule,
    FormsModule,
    HttpClientModule,
    AppRoutingModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }

import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { LoginComponent } from './login/login.component';
import { ProjetDetailComponent } from './projet/projet-detail/projet-detail.component';
import { ProjetFormComponent } from './projet/projet-form/projet-form.component';
import { ProjetListComponent } from './projet/projet-list/projet-list.component';
import { SignupComponent } from './signup/signup.component';

const routes: Routes = [
  { path: '', redirectTo: 'login', pathMatch: 'full' },
  { path: 'login', component: LoginComponent },
  { path: 'signup', component: SignupComponent },
  { path: 'projets', loadChildren: () => import('./projet/projet.module').then(m => m.ProjetModule) },
  /*{path: 'projets', component: ProjetListComponent},
  {path: 'projets/ajouter', component: ProjetFormComponent, pathMatch: 'full'},
  {path: 'projets/:id', component: ProjetDetailComponent}*/
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }

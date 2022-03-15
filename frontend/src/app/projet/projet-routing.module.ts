import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { ProjetDetailComponent } from './projet-detail/projet-detail.component';
import { ProjetFormComponent } from './projet-form/projet-form.component';
import { ProjetListComponent } from './projet-list/projet-list.component';

import { ProjetComponent } from './projet.component';

const routes: Routes = [
  { path: '', component: ProjetComponent, children: [
    {path: '', component: ProjetListComponent},
    {path: ':id', component: ProjetDetailComponent},
    {path: 'ajouter', component: ProjetFormComponent}
    ] 
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class ProjetRoutingModule { }

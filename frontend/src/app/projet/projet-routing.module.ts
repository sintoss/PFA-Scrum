import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { BoardComponent } from './board/board.component';
import { ProjetDetailComponent } from './projet-detail/projet-detail.component';
import { ProjetFormComponent } from './projet-form/projet-form.component';
import { ProjetListComponent } from './projet-list/projet-list.component';
import { ProjetComponent } from './projet.component';

const routes: Routes = [
  {path: '', component: ProjetComponent, children: [
    {path: '', component: ProjetListComponent},
    {path: 'ajouter', component: ProjetFormComponent},
    {path: ':id', component: ProjetDetailComponent},
    {path: ':projetId/sprints/:sprintId', component: BoardComponent}
  ]}
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class ProjetRoutingModule { }

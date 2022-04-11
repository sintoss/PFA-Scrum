import {NgModule} from "@angular/core";
import {CommonModule} from "@angular/common";

import {ProjetRoutingModule} from "./projet-routing.module";
import {ProjetComponent} from "./projet.component";
import {HeaderComponent} from "../header/header.component";
import {SubHeaderComponent} from "../sub-header/sub-header.component";
import {ProjetListComponent} from "./projet-list/projet-list.component";
import {ProjetCardComponent} from "./projet-card/projet-card.component";
import {ProjetDetailComponent} from "./projet-detail/projet-detail.component";
import {ProjetFormComponent} from "./projet-form/projet-form.component";
import {FormsModule} from "@angular/forms";
import {SprintComponent} from "../sprint/sprint.component";
import {TacheModule} from "../tache/tache.module";
import {BdchartComponent} from "./bdchart/bdchart.component";
import {NgApexchartsModule} from "ng-apexcharts";
import {BacklogModule} from '../backlog/backlog.module';
import {AppModule} from '../app.module';
import {SprintModule} from '../sprint/sprint.module';

@NgModule({
  declarations: [
    ProjetComponent,
    HeaderComponent,
    SubHeaderComponent,
    ProjetListComponent,
    ProjetCardComponent,
    ProjetDetailComponent,
    ProjetFormComponent,
    SprintComponent,
    BdchartComponent,
  ],
  imports: [
    CommonModule,
    FormsModule,
    ProjetRoutingModule,
    TacheModule,
    NgApexchartsModule,
    BacklogModule,
    SprintModule
  ],
  providers: [
  ],
  bootstrap: [ProjetComponent],
})
export class ProjetModule {}

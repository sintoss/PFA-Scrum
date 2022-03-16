import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { TacheListComponent } from './tache-list/tache-list.component';
import { TacheItemComponent } from './tache-item/tache-item.component';
import { TacheFormComponent } from './tache-form/tache-form.component';



@NgModule({
  declarations: [TacheListComponent, TacheItemComponent, TacheFormComponent],
  imports: [CommonModule],
  exports: [TacheListComponent, TacheFormComponent]
})
export class TacheModule { }

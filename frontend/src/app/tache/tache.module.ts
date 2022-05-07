import {NgModule} from '@angular/core';
import {CommonModule} from '@angular/common';
import {TacheListComponent} from './tache-list/tache-list.component';
import {TacheItemComponent} from './tache-item/tache-item.component';
import {TacheFormComponent} from './tache-form/tache-form.component';
import {FormsModule, ReactiveFormsModule} from '@angular/forms';
import { QuillModule } from 'ngx-quill'


@NgModule({
  declarations: [TacheListComponent, TacheItemComponent, TacheFormComponent],
  imports: [CommonModule, FormsModule, ReactiveFormsModule, QuillModule],
  exports: [TacheListComponent, TacheFormComponent]
})
export class TacheModule {
}

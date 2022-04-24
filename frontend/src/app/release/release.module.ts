import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ReleaseComponent } from './release.component';
import { ReleaseRoutingModule } from './release-routing.module';
import { AngularFileUploaderModule } from "angular-file-uploader";

@NgModule({
  declarations: [ReleaseComponent],
  imports: [
    CommonModule,
    ReleaseRoutingModule,
    AngularFileUploaderModule
  ]
})
export class ReleaseModule { }

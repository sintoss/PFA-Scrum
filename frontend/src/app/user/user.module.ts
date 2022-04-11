import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { UserRoutingModule } from './user-routing.module';
import { UserComponent } from './user.component';
import { LoginComponent } from './login/login.component';
import { SignupComponent } from './signup/signup.component';
import {FormsModule, ReactiveFormsModule} from '@angular/forms';
import { TermpolicyComponent } from './signup/termpolicy/termpolicy.component';



@NgModule({
  declarations: [UserComponent, LoginComponent, SignupComponent, TermpolicyComponent],
  imports: [
    CommonModule,
    UserRoutingModule,
    FormsModule,
    ReactiveFormsModule
  ],
  bootstrap: [UserComponent]
})
export class UserModule { }

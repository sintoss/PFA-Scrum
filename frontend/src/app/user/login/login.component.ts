import {Component, OnInit, ViewChild} from '@angular/core';
import { Router } from '@angular/router';
import { UserServiceService } from 'src/app/shared/services/user-service.service';
import {NgForm} from '@angular/forms';
import { Login } from 'src/app/shared/models/login.model';
import {authModelModel} from '../../shared/models/authModel.model';



@Component({
 selector: 'app-login',
 templateUrl: './login.component.html',
 styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {


  @ViewChild('f')
  SignupForm!: NgForm;

  FormError = false;

 constructor(private route: Router , private user: UserServiceService) { }

 ngOnInit(): void {
 }

  // tslint:disable-next-line:typedef
  onSubmit()
 {

     this.user.
     tryToLogin(new Login
     (
       this.SignupForm.value.email
       , this.SignupForm.value.password)).subscribe(data => {
       if(data.isAuthenticated){
         const authMd = new authModelModel();
         authMd.id = data.userId;
         authMd.email = data.email;
         authMd.expiresOn = data.expiresOn;
         authMd.isAuthenticated = data.isAuthenticated;
         authMd.message = data.message;
         authMd.token = data.token;
         authMd.username = data.username;
         authMd.roles = data.roles;
         localStorage.setItem("autMd",JSON.stringify(authMd));
         this.route.navigateByUrl('projets');
       }
     },
       error => this.FormError = true  );
  }



}

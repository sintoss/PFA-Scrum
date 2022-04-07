import {Component, OnInit, ViewChild} from '@angular/core';
import { Router } from '@angular/router';
import { UserServiceService } from 'src/app/shared/services/user-service.service';
import {NgForm} from '@angular/forms';
import { Login } from 'src/app/shared/models/login.model';
import {authModelModel} from '../../shared/models/authModel.model';
import {LocalStoragemangerModel} from '../../shared/services/LocalStoragemanger.model';
import Swal from 'sweetalert2';



@Component({
 selector: 'app-login',
 templateUrl: './login.component.html',
 styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {


  @ViewChild('f')
  SignupForm!: NgForm;

  FormError = false;

  dispalyBtn = false;

 constructor(private route: Router , private user: UserServiceService) { }

 ngOnInit(): void {
 }

  // tslint:disable-next-line:typedef
  onSubmit()
 {
   this.dispalyBtn = true;
     this.user.
     tryToLogin(new Login
     (
       this.SignupForm.value.email
       , this.SignupForm.value.password)).subscribe(data => {
       if(data.isAuthenticated){
         let manger = new LocalStoragemangerModel();
         manger.putAccounntInLocal(data);
         Swal.fire({
           title: 'Login avec sccues',
           type: 'success',
           confirmButtonText: 'Allez vers mes Projets!'
         }).then((result) => {
           if (result.value) {
             this.route.navigateByUrl('projets');
             // For more information about handling dismissals please visit
             // https://sweetalert2.github.io/#handling-dismissals
           }
         });
       }
     },
       error => {
         this.FormError = true;
         console.log(error);
       } );
  }



}

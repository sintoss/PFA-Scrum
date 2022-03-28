import {Component, OnInit, ViewChild} from '@angular/core';
import {NgForm} from '@angular/forms';
import {SignupService} from '../../shared/services/signup.service';
import {RegisterModel} from '../../shared/models/RegisterModel.model';
import {RegisterReturnInfoModel} from '../../shared/models/RegisterReturnInfo.model';
import {Router} from '@angular/router';

@Component({
  selector: 'app-signup',
  templateUrl: './signup.component.html',
  styleUrls: ['./signup.component.css']
})
export class SignupComponent implements OnInit {

  @ViewChild('f')
  Form!: NgForm;

  constructor(private route: Router ,private signup:SignupService) { }

  ngOnInit(): void {
  }

  onSubmit(){
    this.signup.tryToRegister(new RegisterModel(
      this.Form.value.FirstName,
      this.Form.value.LastName,
      this.Form.value.Username,
      this.Form.value.email,
      this.Form.value.password)).subscribe(f => {
        const registerInfo = new RegisterReturnInfoModel(f.token,f.expiresOn);
        localStorage.setItem("autMd",JSON.stringify(registerInfo));
        this.route.navigateByUrl('projets');
        },
      error => console.log('sorry'));
  }

}

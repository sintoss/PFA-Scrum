import { Injectable } from '@angular/core';
import {environment} from '../../../environments/environment';
import {HttpClient} from '@angular/common/http';
import {Observable} from 'rxjs';
import {RegisterModel} from '../models/RegisterModel.model';

@Injectable({
  providedIn: 'root'
})
export class SignupService {
  readonly baseUrl = environment.apiUrl;

  constructor(private http: HttpClient) {}

  tryToRegister(rgmodel: RegisterModel): Observable<any>{
    console.log(rgmodel);
    console.log(this.baseUrl);
    return this.http.post(this.baseUrl + '/Auth/register', rgmodel);
  }
}

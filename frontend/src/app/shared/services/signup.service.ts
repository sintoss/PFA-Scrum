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
    const formData: FormData = new FormData();
    formData.append('Username', rgmodel.username);
    formData.append('Email', rgmodel.email);
    formData.append('Password', rgmodel.password);
    formData.append('acctype', rgmodel.acctype);
    formData.append('file', rgmodel.file, rgmodel.file.name);
    return this.http.post(this.baseUrl + '/Auth/register', formData);
  }
}

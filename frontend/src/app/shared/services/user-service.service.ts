import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { HttpClient} from '@angular/common/http';
import { Login } from '../models/login.model';
import {Observable} from 'rxjs';
import { Utilisateur } from '../models/utilisateur.model';

@Injectable({
  providedIn: 'root'
})
export class UserServiceService {

  readonly baseUrl = environment.apiUrl;

  constructor(private http: HttpClient) {}

  tryToLogin(lg: Login): Observable<any>{
     return this.http.post(this.baseUrl + '/Auth/token', lg);
  }

  getUsers():Observable<Utilisateur[]>
  {
    return this.http.get<Utilisateur[]>(this.baseUrl + "/utilisateurs");
  }

}

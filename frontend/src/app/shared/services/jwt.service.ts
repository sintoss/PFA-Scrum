import { HttpEvent, HttpHandler, HttpInterceptor, HttpRequest } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { JwtModel } from '../models/jwtModel.model';

@Injectable({
  providedIn: 'root'
})
export class JwtService implements HttpInterceptor{

  jwt!: JwtModel;
  token : any;

  constructor(private router: Router) {
    this.InjectToken();
  }

  isAuthenticated(): boolean
  {
    return this.jwt.isAuthenticated;
  }
  getUserId(): string
  {
    return this.jwt.id;
  }
  getObject(): Object
  {
    return {
      username: this.jwt.username,
      email: this.jwt.email,
      pathImage: this.jwt.pathImage,
      roles: this.jwt.roles
    }
  }
  getRoles(): any
  {
    return this.jwt.roles;
  }
  intercept(req: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
    this.InjectToken();
    if(this.jwt){
            req = req.clone({
            headers: req.headers.set('Authorisation', `${this.jwt.token}`)});
    }
    return next.handle(req);
  }

  InjectToken(){
    this.token = localStorage.getItem('autMd');
    if(this.token) this.jwt = JSON.parse(this.token)
  }

}

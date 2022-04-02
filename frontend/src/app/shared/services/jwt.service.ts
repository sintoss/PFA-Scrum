import { HttpEvent, HttpHandler, HttpInterceptor, HttpRequest } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { JwtModel } from '../models/jwtModel.model';

@Injectable({
  providedIn: 'root'
})
export class JwtService implements HttpInterceptor{

  jwt: JwtModel;
  
  constructor() {
    let token = localStorage.getItem("autMd") || "";
    this.jwt = JSON.parse(token);
  }
  isAuthenticated(): boolean
  {
    return this.jwt.isAuthenticated;
  }
  getUserId(): string
  {
    return this.jwt.id;
  }
  intercept(req: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
      req = req.clone({
        headers: req.headers.set("Authorisation", `${this.jwt.token}`)
      });

    return next.handle(req);
  }
}

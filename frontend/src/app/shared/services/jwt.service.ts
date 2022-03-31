import { HttpEvent, HttpHandler, HttpInterceptor, HttpRequest } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class JwtService implements HttpInterceptor{

  jwt = {
    email: "",
    expiresOn: "",
    id: "",
    isAuthenticated: false,
    message: null,
    roles: [],
    token: "",
    username: ""
  };
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

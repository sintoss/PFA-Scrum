import { Injectable } from '@angular/core';
import {environment} from '../../../environments/environment';
import {TacheModel} from '../models/tache.model';
import {HttpClient} from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class ReleaseService {

  readonly baseUrl = environment.apiUrl;


  constructor(private http: HttpClient) { }

  getRelease() {
    return this.http.get(this.baseUrl + '/Release');
  }

  downloadrelease(id:number|string) {
    return this.http.get(this.baseUrl + `/Release/download/${id}` , {responseType:'blob'} );
  }

}

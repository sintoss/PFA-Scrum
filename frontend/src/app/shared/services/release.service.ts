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

  getStoryTaches() {
    return this.http.get(this.baseUrl + '/Release');
  }

}

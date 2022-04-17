import { Injectable } from '@angular/core';
import {environment} from '../../../environments/environment';
import {HttpClient} from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class DeveloppeurStoryService {
  readonly baseUrl = environment.apiUrl;
  constructor(private http:HttpClient) { }

  insertDevStory(value:any){
    return this.http.post(this.baseUrl+"/DeveloppeurStories",value,{ responseType: 'text' });
  }

}

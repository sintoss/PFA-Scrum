import { Injectable } from '@angular/core';
import {environment} from '../../../environments/environment';
import {Observable} from 'rxjs';
import {Story} from '../models/story.model';
import {HttpClient} from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class StoryService {
  readonly baseUrl = environment.apiUrl;
  constructor(private http: HttpClient) { }

   getStoryList(): Observable<any[]> {
     return this.http.get<any[]>(this.baseUrl + '/Story');
   }

   getStoryListByBacklogId(bckid: number | string , pg: number ): Observable<any[]> {
    return this.http.get<any[]>(this.baseUrl + `/Story/${bckid}/${pg}`);
   }

  // tslint:disable-next-line:typedef
   addStory(data: any){
    return this.http.post(this.baseUrl + '/Story', data);
   }

  // tslint:disable-next-line:typedef
   updateStory(id: number | string , data: any){
     return this.http.put(this.baseUrl + `/Story/${id}`, data);
   }
  // tslint:disable-next-line:typedef
   deleteStory(id: number | string){
    return this.http.delete(this.baseUrl + `/Story/${id}`);
  }

}
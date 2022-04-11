import { Injectable } from '@angular/core';
import {environment} from '../../../environments/environment';
import {Observable} from 'rxjs';
import {HttpClient} from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class SprintService {

  readonly baseUrl = environment.apiUrl;

  constructor(private http:HttpClient) { }

  addSprint(value:any) : Observable<any> {
      return this.http.post(this.baseUrl+"/Sprints",value,{ responseType: 'text' });
  }

  getSprints( pg: number| string , pgs: number | string = 5 , lib : string = " "   ):Observable<any[]> {
    return this.http.get<any[]>(this.baseUrl+`/Sprints/${pg}/${pgs}/${lib}`);
  }

  editSprints(value:any) : Observable<any> {
    return this.http.put(this.baseUrl + `/Sprints/${value.Id}`, value, {responseType: 'text'});
  }

  deleteSprint(id: number | string){
    return this.http.delete(this.baseUrl + `/Sprints/${id}`, {responseType: 'text'});
  }

}

import { Injectable } from '@angular/core';
import {environment} from '../../../environments/environment';
import {HttpClient} from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class DetailsprintService {
  readonly baseUrl = environment.apiUrl;
  sprintId!:number;

  constructor(private http: HttpClient) { }

  setValueOfSprint(vl:any){
    this.sprintId = vl;
  }

  getValueOfSprint(){
    return this.sprintId;
  }

  getAllOfstoryOfthisSprint(pg: number| string , pgs: number | string = 5 , desc : string = " " ){
    return this.http.get(this.baseUrl+`/Sprints/story/${this.sprintId}/${pg}/${pgs}/${desc}`);
  }


}

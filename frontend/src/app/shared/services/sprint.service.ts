import { Injectable } from '@angular/core';
import {environment} from '../../../environments/environment';
import {Observable , Subject} from 'rxjs';
import {HttpClient} from '@angular/common/http';
import {ActivatedRoute} from '@angular/router';

@Injectable({
  providedIn: 'root'
})
export class SprintService {

  readonly baseUrl = environment.apiUrl;

  sprintId!:number;
  subject$ = new Subject<any>();

  emitData(sprintId:any){
       this.subject$.next(sprintId);
  }

  returnSprint(){
    return this.subject$.asObservable();
  }



  constructor(private http:HttpClient ,  private router: ActivatedRoute) { }

  addSprint(value:any) : Observable<any> {
      return this.http.post(this.baseUrl+"/Sprints",value,{ responseType: 'text' });
  }

  getSprints( backId: number| string ,pg: number| string , pgs: number | string = 5 , lib : string = " "   ):Observable<any[]> {
    return this.http.get<any[]>(this.baseUrl+`/Sprints/${backId}/${pg}/${pgs}/${lib}`);
  }

  editSprints(value:any) : Observable<any> {
    return this.http.put(this.baseUrl + `/Sprints/${value.Id}`, value, {responseType: 'text'});
  }

  deleteSprint(id: number | string){
    return this.http.delete(this.baseUrl + `/Sprints/${id}`, {responseType: 'text'});
  }

  getStorydosnthaveSprint(bckid: number | string, desc : string = " "): Observable<any[]> {
    return this.http.get<any[]>(this.baseUrl + `/Sprints/affection/${bckid}/${desc}`);
  }

  addMyListOfSotryToSprint(value:any) : Observable<any> {
    return this.http.post(this.baseUrl+"/Sprints/aff",value,{ responseType: 'text' });
  }

}

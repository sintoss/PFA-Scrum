import {Injectable} from '@angular/core';
import {environment} from '../../../environments/environment';
import {Observable, Subject} from 'rxjs';
import {HttpClient} from '@angular/common/http';
import {ActivatedRoute} from '@angular/router';
import { Story } from '../models/story.model';
import { SprintModule } from 'src/app/sprint/sprint.module';

@Injectable({
  providedIn: 'root'
})
export class SprintService {

  readonly baseUrl = environment.apiUrl;

  sprintId!: number;
  subject$ = new Subject<any>();
  subject2$ = new Subject<boolean>();
  subject3$ = new Subject<boolean>();

  emitData3(trv: boolean) {
    this.subject3$.next(trv);
  }

  returnSprint3() {
    return this.subject3$.asObservable();
  }

  emitData2(trv: boolean) {
    this.subject2$.next(trv);
  }

  returnSprint2() {
    return this.subject2$.asObservable();
  }

  emitData(sprintId: any) {
    this.subject$.next(sprintId);
  }

  returnSprint() {
    return this.subject$.asObservable();
  }


  constructor(private http: HttpClient, private router: ActivatedRoute) {
  }

  addSprint(value: any): Observable<any> {
    return this.http.post(this.baseUrl + '/Sprints', value, {responseType: 'text'});
  }

  getSprints(backId: number | string, pg: number | string, pgs: number | string = 5, lib: string = ' '): Observable<any[]> {
    return this.http.get<any[]>(this.baseUrl + `/Sprints/${backId}/${pg}/${pgs}/${lib}`);
  }

  editSprints(value: any): Observable<any> {
    return this.http.put(this.baseUrl + `/Sprints/${value.Id}`, value, {responseType: 'text'});
  }

  deleteSprint(id: number | string) {
    return this.http.delete(this.baseUrl + `/Sprints/${id}`, {responseType: 'text'});
  }

  getStorydosnthaveSprint(bckid: number | string, desc: string = ' '): Observable<any[]> {
    return this.http.get<any[]>(this.baseUrl + `/Sprints/affection/${bckid}/${desc}`);
  }

  addMyListOfSotryToSprint(value: any): Observable<any> {
    return this.http.post(this.baseUrl + '/Sprints/aff', value, {responseType: 'text'});
  }

  getCurrentSprint(backId: number) {
    return this.http.get(this.baseUrl + '/Sprints/CurrentSprint/' + backId);
  }
  getMySprint(sprintId: number):Observable<Story[]>
  {
    return this.http.get<Story[]>(this.baseUrl + `/Sprints/${sprintId}`);
  }
  completeSprint(sprintId: number, sprint: SprintModule):Observable<SprintModule>
  {
    return this.http.put<SprintModule>(this.baseUrl + `/Sprints/${sprintId}/completer`, sprint);
  }

  getCheckForSprint(){
    return this.http.get(this.baseUrl + '/Sprints/check');
  }

}

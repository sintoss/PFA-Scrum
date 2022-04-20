import {HttpClient} from '@angular/common/http';
import {Injectable} from '@angular/core';
import {Observable, Subject} from 'rxjs';
import {environment} from 'src/environments/environment';
import {Backlog} from '../models/backlog.model';

@Injectable({
  providedIn: 'root'
})
export class BacklogService {
  readonly baseUrl = environment.apiUrl;
  backlog: Backlog = new Backlog();
  backId: Subject<any>;

  setBackId(value: number) {
    this.backId.next(value);
  }

  constructor(private http: HttpClient) {
    this.backId = new Subject<any>();
  }

  setBacklog(projetId: number): Observable<Backlog> {
    this.backlog.projetId = projetId;
    this.backlog.dateCreation = new Date();
    return this.http.post<Backlog>(this.baseUrl + '/backlog/ajouter', this.backlog);
  }


}

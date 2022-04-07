import {HttpClient} from '@angular/common/http';
import {Injectable} from '@angular/core';
import {Observable} from 'rxjs';
import {environment} from 'src/environments/environment';
import {Backlog} from '../models/backlog.model';

@Injectable({
  providedIn: 'root'
})
export class BacklogService {
  readonly baseUrl = environment.apiUrl;
  backlog: Backlog = new Backlog();


  constructor(private http: HttpClient) { }

  setBacklog(projetId: number): Observable<Backlog>
  {
      this.backlog.projetId = projetId;
      this.backlog.dateCreation = new Date();
      return this.http.post<Backlog>(this.baseUrl + '/backlog/ajouter', this.backlog);
  }

}

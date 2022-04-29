import {Injectable} from '@angular/core';
import {HttpClient} from '@angular/common/http';
import {TacheModel} from '../models/tache.model';
import {environment} from '../../../environments/environment';
import {Observable} from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class TacheService {
  readonly baseUrl = environment.apiUrl;

  constructor(private http: HttpClient) {
  }

  postTaches(tache: TacheModel): Observable<any> {
    return this.http.post(this.baseUrl + '/Taches', tache);
  }

  getStoryTaches(storyId: number, pg: number | string, pgs: number | string = 5, desc: string = ' ') {
    return this.http.get<TacheModel[]>(this.baseUrl + `/Taches/StoryTaches/${storyId}/${pg}/${pgs}/${desc}`);
  }

  updateTache(id: number, model: TacheModel) {
    return this.http.put(this.baseUrl + `/Taches/${id}`, model);
  }

  deleteTache(id: number) {
    return this.http.delete(this.baseUrl + `/Taches/${id}`);
  }

  completeTache(tache: TacheModel): Observable<TacheModel> {
    return this.http.put<TacheModel>(this.baseUrl + `/Taches/${tache.id}/completer`, tache);
  }
}

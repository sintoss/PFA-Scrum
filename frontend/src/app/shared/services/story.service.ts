import {Injectable} from '@angular/core';
import {environment} from '../../../environments/environment';
import {Observable} from 'rxjs';
import {Story} from '../models/story.model';
import {HttpClient} from '@angular/common/http';
import {StoryView} from '../models/story-view.model';

@Injectable({
  providedIn: 'root'
})
export class StoryService {
  readonly baseUrl = environment.apiUrl;

  constructor(private http: HttpClient) {
  }

  getStoryList(): Observable<any[]> {
    return this.http.get<any[]>(this.baseUrl + '/Story');
  }

  getStoryListByBacklogId(bckid: number | string, pg: number | string, pgs: number | string = 5, desc: string = ' '): Observable<any[]> {
    return this.http.get<any[]>(this.baseUrl + `/Story/${bckid}/${pg}/${pgs}/${desc}`);
  }

  // tslint:disable-next-line:typedef
  addStory(data: any) {
    return this.http.post(this.baseUrl + '/Story', data);
  }

  // tslint:disable-next-line:typedef
  updateStory(id: number | string, data: any) {
    console.log(data);
    return this.http.put(this.baseUrl + `/Story/${id}`, data);
  }

  // tslint:disable-next-line:typedef
  deleteStory(id: number | string) {
    return this.http.delete(this.baseUrl + `/Story/${id}`);
  }

  // tslint:disable-next-line:typedef
  getImagePath(UserStoryId: number | string) {
    return this.http.get(this.baseUrl + `/Story/UserStoryId?UserStoryId=${UserStoryId}`, {responseType: 'text'});
  }

  storyStateChanged(storyId: number, story: StoryView): Observable<Story> {
    return this.http.put<Story>(this.baseUrl + `/Story/${storyId}/changerEtat`, story);
  }

  GetWorkLeftForDev(id: number | string, bckid: number | string) {
    return this.http.get(this.baseUrl + `/Story/checkWorkLeftForDev/${id}/${bckid}`);
  }

  initStory(id: number | string) {
    return this.http.delete(this.baseUrl + `/Story/Init/${id}`);
  }

  getAllStoriesById(backId: number) {
    return this.http.get(this.baseUrl + '/Story/AllStoriesByID/' + backId);
  }

}

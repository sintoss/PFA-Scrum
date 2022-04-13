import {Injectable} from '@angular/core';
import {Observable, Subject} from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class TachManagerService {

  storyId!: number;
  private subject = new Subject<any>();

  constructor() {
  }

  // tslint:disable-next-line:typedef
  sendClickEvent(id: number) {
    this.storyId = id;
    this.subject.next(id);
  }

  getClickEvent(): Observable<any> {
    return this.subject.asObservable();
  }
}

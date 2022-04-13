import {Injectable} from '@angular/core';
import {Observable, Subject} from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class SearchService {

  private subject = new Subject<any>();

  constructor() {
  }

  sendClickEvent(help: boolean) {
    this.subject.next(help);
  }

  getClickEvent(): Observable<any> {
    return this.subject.asObservable();
  }
}

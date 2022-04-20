import { Injectable } from '@angular/core';
import {Subject} from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class DetectTeamProjectService {

  subject$ = new Subject<any>();

  teamchange(dtc:boolean){
    this.subject$.next(dtc);
  }

  returnobj(){
    return this.subject$.asObservable();
  }


  constructor() { }
}

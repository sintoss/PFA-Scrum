import { Injectable } from '@angular/core';
import {Story} from '../models/story.model';

@Injectable({
  providedIn: 'root'
})
export class TachmangerService {

  constructor() { }

  str!:any;

  getValue(){
    return this.str;
  }

  setValue(vl:any){
    this.str = vl;
  }

}

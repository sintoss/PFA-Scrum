import { Injectable } from '@angular/core';
import {Story} from '../models/story.model';

@Injectable({
  providedIn: 'root'
})
export class TachmangerService {

  constructor() { }

  userstory!:Story;

  public get UserStory() {
    return this.UserStory;
  }

  public set UserStory(val:any) {
    this.UserStory = val;
  }

}

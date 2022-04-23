import { DeveloppeurStory } from "./developpeurStory.model";
import { Etat } from "./Etat.model";
import { SprintStory } from "./sprint-story.model";
import { TacheModel } from "./tache.model";
import { TesteurStory } from "./testeurStory.model";
export class Story {

  id!:number;
  description!: string ;
  dateCreation!: Date;
  dateDebut!: Date;
  datePrevuFin!: Date;
  dateFin!: Date;
  dateDerniereModification!: Date;
  commentaire!: string;
  backlogId!:number;
  sprintStories!: Array<SprintStory>;
  taches!: Array<TacheModel>;
  etat!:Etat;
  developpeurStories!: Array<DeveloppeurStory>;
  testeurStories!: Array<TesteurStory>;
  
  constructor() {}


}

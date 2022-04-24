import { DeveloppeurStory } from "./developpeurStory.model";
import { Etat } from "./Etat.model";
import { Story } from "./story.model";
export class StoryView {

  id!:number;
  description!: string ;
  dateCreation!: Date;
  dateDebut!: Date;
  datePrevuFin!: Date;
  dateFin!: Date;
  dateDerniereModification!: Date;
  commentaire!: string;
  backlogId!:number;
  duree!: number;
  etat!:Etat;
  
  constructor(story:Story) {
    this.id = story.id;
    this.description = story.description;
    this.dateCreation = story.dateCreation;
    this.dateDebut = story.dateDebut;
    this.datePrevuFin = story.datePrevuFin;
    this.dateFin = story.dateFin;
    this.dateDerniereModification = story.dateDerniereModification;
    this.commentaire = story.commentaire;
    this.backlogId = story.backlogId;
    this.duree = story.duree;
    this.etat = story.etat;
  }


}

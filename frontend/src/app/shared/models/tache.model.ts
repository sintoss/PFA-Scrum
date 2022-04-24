export class TacheModel {


  id!: number;
  libelle!: string;
  description!: string;
  dateCreation!: Date;
  dateDerniereModification!: Date;
  etat!: boolean;
  storyId!: number;


  constructor() {
  }
}

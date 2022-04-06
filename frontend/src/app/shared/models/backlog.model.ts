<<<<<<< Updated upstream
import {Projet} from './projet.model';
import {Story} from './story.model';

export class Backlog {
  id!: number;
  dateCreation!: Date;
  dateDernierModification!: Date;
  projetId!: number;
  projet!: Projet;
  stories!: Story[];
=======
import { Projet } from './projet.model';
import { Story } from './story.model';

export class Backlog {
    id!: number;
    dateCreation!: Date;
    dateDernierModification!: Date;
    projetId!: number;
    projet!: Projet;
    stories!: Story[];
>>>>>>> Stashed changes
}

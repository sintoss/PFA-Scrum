import { Projet } from "./projet.model";
import { Story } from "./story.model";

export class Backlog {
    id!: number;
    dateCreation!: Date;
    dateDernierModification!: Date;
    projet!: Projet;
    stories!: Story[];
}
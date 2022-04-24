import { Backlog } from "./backlog.model";

export class Sprint {
    id!: number;
    libelle!: string;
    dateCreation!: Date;
    dateDernierModification!: Date;
    Dateestimeedefin!: Date;
    backlogId!: number;
    dureeSprint!: number;
    jourTravail!: number;
    finDeSprint!: boolean;

    constructor(){}
    /*constructor(s:Sprint)
    {
        this.id = s.id;
        this.libelle = s.libelle;
        this.backlogId = s.backlogId;
        this.dateCreation = s.dateCreation;
        this.dateDernierModification = s.dateDernierModification;
        this.dureeSprint = s.dureeSprint;
        this.Dateestimeedefin = s.Dateestimeedefin;
        this.finDeSprint = s.finDeSprint;
        this.jourTravail = s.jourTravail;
    }*/
}
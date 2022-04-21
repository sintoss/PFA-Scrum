import { Backlog } from "./backlog.model";
import { Reunion } from "./reunion.model";
import { ScrumMaster } from "./scrumMaster.model";
import { ScrumMasterProjet } from "./scrumMasterProjet.model";
import { UtilisateurProjet } from "./utilisateurProjet.model";

export class Projet {
    id!: number;
    nom!: string;
    dateCreation!: Date;
    dateDebut!: Date;
    datePrevueFin!: Date;
    dureeSprint!: number;
    jourTravail!: number;
    backlog!: Backlog;
    scrumMasterId!: string;
    scrumMaster!: ScrumMaster;
    reunions!: Reunion[];
    utilisateurProjets!: UtilisateurProjet[];
    scrumMasterProjet!: ScrumMasterProjet[];
}
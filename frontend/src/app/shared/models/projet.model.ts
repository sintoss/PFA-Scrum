import { Backlog } from "./backlog.model";
import { Reunion } from "./reunion.model";
import { ScrumMaster } from "./scrumMaster.model";
import { ScrumMasterProjet } from "./scrumMasterProjet.model";
import { UtilisateurProjet } from "./utilisateurProjet.model";

export class Projet {
    id!: number;
    nom!: string;
    dateCreation!: Date;
    datePrevueFin!: Date;
    backlog!: Backlog;
    scrumMasterId!: number;
    scrumMaster!: ScrumMaster;
    reunions!: Reunion[];
    utilisateurProjets!: UtilisateurProjet[];
    scrumMasterProjet!: ScrumMasterProjet[];
}
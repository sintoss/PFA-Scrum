import { Backlog } from "./backlog.model";
import { Reunion } from "./reunion.model";
import { ScrumMaster } from "./scrumMaster.model";
import { ScrumMasterProjet } from "./scrumMasterProjet.model";
import { UtilisateurProjet } from "./utilisateurProjet.model";

export class ProjetModel {
    id!: number;
    nom!: string;
    dateDebut!: Date;
    datePrevueFin!: Date;
    storyNumber!: number;
}
import { Projet } from "./projet.model";
import { Utilisateur } from "./utilisateur.model"

export class UtilisateurProjet {
    utilisateurId!: string;
    utilisateur!: Utilisateur;
    projetId!: number;
    projet!: Projet;

    constructor(userId: string, projetId: number)
    {
        this.utilisateurId = userId;
        this.projetId = projetId;
    }
}
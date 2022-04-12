import {Injectable} from '@angular/core';
import {environment} from 'src/environments/environment';
import {Projet} from '../models/projet.model';
import {HttpClient} from '@angular/common/http';
import {Observable} from 'rxjs';
import { UtilisateurProjet } from '../models/utilisateurProjet.model';
import { ProjetModel } from '../models/projet-model.model';

@Injectable({
  providedIn: 'root'
})
export class ProjetService {

  readonly baseUrl = environment.apiUrl;
  projet: Projet = new Projet();

  constructor(private http: HttpClient) {
    
  }

  getMyProjets(): Observable<ProjetModel[]> {
    return this.http.get<ProjetModel[]>(this.baseUrl + '/projets');
  }

  getProjetDetail(projetId: number): Observable<Projet> {
    return this.http.get<Projet>(this.baseUrl + '/projets/' + projetId);
  }

  setProjet(scrumMasterId: string): Observable<Projet> {
    this.projet.scrumMasterId = scrumMasterId;
    this.projet.dateCreation = new Date();
    return this.http.post<Projet>(this.baseUrl + '/projets/ajouter', this.projet);
  }
  setProjetMembres(projetId: number, utilisateurProjets: UtilisateurProjet[]): Observable<UtilisateurProjet[]>
  {
    return this.http.post<UtilisateurProjet[]>(this.baseUrl + `/projets/${projetId}/membres/ajouter`, utilisateurProjets);
  }
  deleteMembre(projetId: number, userId: string): Observable<UtilisateurProjet>
  {
    return this.http.delete<UtilisateurProjet>(this.baseUrl + `/Projets/${projetId}/membres/supprimer/${userId}`);
  }
}

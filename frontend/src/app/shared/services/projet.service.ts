import {Injectable} from '@angular/core';
import {environment} from 'src/environments/environment';
import {Projet} from '../models/projet.model';
import {HttpClient} from '@angular/common/http';
import {Observable} from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ProjetService {

  readonly baseUrl = environment.apiUrl;
  projet: Projet = new Projet();

  constructor(private http: HttpClient) {

  }

  getMyProjets(): Observable<Projet[]> {
    return this.http.get<Projet[]>(this.baseUrl + '/projets');
  }

  getProjetDetail(projetId: number): Observable<Projet> {
    return this.http.get<Projet>(this.baseUrl + '/projets/' + projetId);
  }

  setProjet(scrumMasterId: string): Observable<Projet> {
    this.projet.scrumMasterId = scrumMasterId;
    this.projet.dateCreation = new Date();
    return this.http.post<Projet>(this.baseUrl + '/projets/ajouter', this.projet);
  }
}

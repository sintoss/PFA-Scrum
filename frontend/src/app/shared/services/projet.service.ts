import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { Projet } from '../models/projet.model';
import { HttpClient} from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class ProjetService {

  readonly baseUrl = environment.apiUrl;
  projet: Projet = new Projet();

  constructor(private http: HttpClient) {

  }

  getById(projetId: number): Projet
  {
    const url = this.baseUrl + '/projet/' + Number.toString();
    const projet = new Projet();
    return projet;
  }
  // tslint:disable-next-line:typedef
  setProjet()
  {
    this.projet.scrumMasterId = 1;
    return this.http.post(this.baseUrl + '/projets/ajouter', this.projet);
  }
}

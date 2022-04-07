import {Injectable} from "@angular/core";
import {HttpClient} from "@angular/common/http";
import {TacheModel} from "../models/tache.model";
import {environment} from "../../../environments/environment";
import {Observable} from "rxjs";

@Injectable({
  providedIn: "root",
})
export class TacheService {
  readonly baseUrl = environment.apiUrl;

  constructor(private http: HttpClient) {}

  postTaches(tache: TacheModel): Observable<any> {
    return this.http.post(this.baseUrl + "/Taches", tache);
  }
}

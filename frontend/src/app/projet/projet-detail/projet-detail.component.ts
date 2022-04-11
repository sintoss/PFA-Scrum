import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { Projet } from 'src/app/shared/models/projet.model';
import { Utilisateur } from 'src/app/shared/models/utilisateur.model';
import { UtilisateurProjet } from 'src/app/shared/models/utilisateurProjet.model';
import { ProjetService } from 'src/app/shared/services/projet.service';
import { UserServiceService } from 'src/app/shared/services/user-service.service';
import { environment } from 'src/environments/environment';
import Swal from 'sweetalert2';

@Component({
  selector: 'app-projet-detail',
  templateUrl: './projet-detail.component.html',
  styleUrls: ['./projet-detail.component.css']
})
export class ProjetDetailComponent implements OnInit {

  readonly baseUrl = environment.apiUrl;
  projet: Projet;
  users: Array<Utilisateur>;
  usersInput: Array<Utilisateur>;
  usersProjets: Array<UtilisateurProjet>

  constructor(private router: ActivatedRoute,private projetService: ProjetService, private http: HttpClient, private userService: UserServiceService) {
    this.projet = new Projet();
    this.users = new Array<Utilisateur>();
    this.usersInput = new Array<Utilisateur>();
    this.usersProjets = new Array<UtilisateurProjet>();
   }

  ngOnInit(): void {
    let id = (Number) (this.router.snapshot.paramMap.get("id"));
    this.projetService.getProjetDetail(id).subscribe(
      res => {
        Object.assign(this.projet, res);
      }
    )
  }
  getUsers()
  {
    this.userService.getUsers().subscribe(
      res => {
        this.users = [...res];
        this.usersInput = this.users.filter(u => !this.projet.utilisateurProjets.some(up => up.utilisateur.userName === u.userName));
      },
      err => console.log(err)
    );
  }
  getResult(event: any)
  {
    let username = event.target.value;
    this.usersInput = this.users.filter(user => user.userName.includes(username) && !this.projet.utilisateurProjets.some(up => up.utilisateur.userName === user.userName));
  }
  setUsersProjets(id:string, e: Event)
  {
    let userProjet = new UtilisateurProjet(id, this.projet.id);
    if((<HTMLInputElement>e.target).checked) {
        this.usersProjets.push(userProjet);
    } else {
      let index = this.usersProjets.indexOf(userProjet);
      this.usersProjets.splice(index, 1);
    }
  }
  addMembres()
  {
    console.log(this.usersProjets);
    this.projetService.setProjetMembres(this.projet.id, this.usersProjets).subscribe(
      res => {
        console.log(res);
        this.projet.utilisateurProjets = [...res];
        this.usersProjets = [];
        Swal.fire(
          'Ajouté!',
          'Le membre a ete ajouter avec succes.',
          'success'
        );
        let model = document.getElementById('membremodal');
        if(model != null) model.click();
      },
      err => console.log(err)
    )
  }
  supprimerMembre(userId: string)
  {
    Swal.fire({
      title: 'Etes vous sure de vouloir supprimer ce membre du projet?',
      type: 'warning',
      showCancelButton: true,
      confirmButtonColor: '#3085d6',
      cancelButtonColor: '#d33',
      confirmButtonText: 'Oui, Je Comfirme!'
    }).then((result) => {
      if (result.value) {
        this.projetService.deleteMembre(this.projet.id, userId).subscribe(
          res=> {
            this.projet.utilisateurProjets = this.projet.utilisateurProjets.filter(up => up.utilisateurId !== res.utilisateurId);
            //this.usersInput.push(res.utilisateur);
            Swal.fire(
              'Supprimé!',
              'Le membre a ete supprimer avec succes.',
              'success'
            );
          },
          error => console.log(error));
      }
    })
  }
}

import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { Router } from '@angular/router';
import { Observable } from 'rxjs';
import { Projet } from 'src/app/shared/models/projet.model';
import { JwtService } from 'src/app/shared/services/jwt.service';
import { ProjetService } from 'src/app/shared/services/projet.service';
import Swal from 'sweetalert2';

@Component({
  selector: 'app-projet-form',
  templateUrl: './projet-form.component.html',
  styleUrls: ['./projet-form.component.css']
})
export class ProjetFormComponent implements OnInit {
  
  constructor(public projetService: ProjetService, private jwt: JwtService, private route: Router) {
  }

  ngOnInit(): void {
  }

  onSubmit(projetForm: NgForm)
  {
    this.projetService.setProjet(this.jwt.getUserId()).subscribe(
      res => {
        Swal.fire({
          title: 'Le projet: ' + res.nom + " a été crée avec succes",
          type: 'success',
          showCancelButton: true,
          confirmButtonText: 'Allez vers mes Projets!',
          cancelButtonText: 'Ajouter d\'autre projet'
        }).then((result) => {
          if (result.value) {
            this.route.navigateByUrl('projets');
          // For more information about handling dismissals please visit
          // https://sweetalert2.github.io/#handling-dismissals
          }
        });
      },
      err => {console.log(err)}
    );
  }

}

import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { Observable } from 'rxjs';
import { Projet } from 'src/app/shared/models/projet.model';
import { JwtService } from 'src/app/shared/services/jwt.service';
import { ProjetService } from 'src/app/shared/services/projet.service';

@Component({
  selector: 'app-projet-form',
  templateUrl: './projet-form.component.html',
  styleUrls: ['./projet-form.component.css']
})
export class ProjetFormComponent implements OnInit {
  
  constructor(public projetService: ProjetService, private jwt: JwtService) {
  }

  ngOnInit(): void {
  }

  onSubmit(projetForm: NgForm)
  {
    this.projetService.setProjet(this.jwt.getUserId()).subscribe(
      res => {
        console.log(typeof res);
        console.log(res);
      },
      err => {console.log(err)}
    );
  }

}

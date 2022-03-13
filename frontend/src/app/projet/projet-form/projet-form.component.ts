import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { Observable } from 'rxjs';
import { Projet } from 'src/app/shared/models/projet.model';
import { ProjetService } from 'src/app/shared/services/projet.service';

@Component({
  selector: 'app-projet-form',
  templateUrl: './projet-form.component.html',
  styleUrls: ['./projet-form.component.css']
})
export class ProjetFormComponent implements OnInit {
  
  constructor(public projetService: ProjetService) {
  }

  ngOnInit(): void {
  }

  onSubmit(projetForm: NgForm)
  {
    this.projetService.setProjet().subscribe(
      res => {

      },
      err => {console.log(err)}
    );
  }

}

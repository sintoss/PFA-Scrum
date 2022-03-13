import { Component, Input, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Projet } from 'src/app/shared/models/projet.model';
import { ProjetService } from 'src/app/shared/services/projet.service';

@Component({
  selector: 'app-projet-card',
  templateUrl: './projet-card.component.html',
  styleUrls: ['./projet-card.component.css']
})
export class ProjetCardComponent implements OnInit {
  @Input() projet: Projet;

  constructor(projetService: ProjetService, router: Router) {
    this.projet = new Projet();
  }

  ngOnInit(): void {
  }

}

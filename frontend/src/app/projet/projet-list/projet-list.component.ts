import { Component, OnInit } from '@angular/core';
import { Projet } from 'src/app/shared/models/projet.model';
import { ProjetService } from 'src/app/shared/services/projet.service';

@Component({
  selector: 'app-projet-list',
  templateUrl: './projet-list.component.html',
  styleUrls: ['./projet-list.component.css']
})
export class ProjetListComponent implements OnInit {
  projets: Projet[];
  constructor(private projetService: ProjetService) {
    this.projets = new Array<Projet>();
  }

  ngOnInit(): void {
    this.projetService.getMyProjets().subscribe(
      res => this.projets.push(...res)
    );
  }

}

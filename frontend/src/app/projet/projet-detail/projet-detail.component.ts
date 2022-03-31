import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Projet } from 'src/app/shared/models/projet.model';
import { ProjetService } from 'src/app/shared/services/projet.service';

@Component({
  selector: 'app-projet-detail',
  templateUrl: './projet-detail.component.html',
  styleUrls: ['./projet-detail.component.css']
})
export class ProjetDetailComponent implements OnInit {
  projet: Projet;
  constructor(private projetService: ProjetService, private router: ActivatedRoute) {
    this.projet = new Projet();
   }

  ngOnInit(): void {
    let id = (Number) (this.router.snapshot.paramMap.get("id"));
    this.projetService.getProjetDetail(id).subscribe(
      res => Object.assign(this.projet, res)
    )
  }

}

import { HttpClient } from '@angular/common/http';
import { Component, Input, OnInit } from '@angular/core';
import { environment } from 'src/environments/environment';
import { Backlog } from '../shared/models/backlog.model';
import { BacklogService } from '../shared/services/backlog.service';

@Component({
  selector: 'app-backlog',
  templateUrl: './backlog.component.html',
  styleUrls: ['./backlog.component.css']
})
export class BacklogComponent implements OnInit {
  @Input() projetId: number;
  @Input() backlog: Backlog;
  constructor(private http: HttpClient, private backlogService: BacklogService) {
      this.projetId = 0;
      this.backlog = new Backlog();
  }

  ngOnInit(): void {
  }

  createBacklog()
  {
    let backlog = new Backlog();
    backlog.dateCreation = new Date();
    backlog.projetId = this.projetId;
    this.http.post<Backlog>(environment.apiUrl + "/backlog/ajouter", backlog).subscribe(
      res => console.log(res),
      err => console.log(err)
    )
  }

}

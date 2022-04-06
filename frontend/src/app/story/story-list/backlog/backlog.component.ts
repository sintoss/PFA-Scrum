import { HttpClient } from '@angular/common/http';
import {Component, EventEmitter, Input, OnInit, Output, ViewChild} from '@angular/core';
import { environment } from 'src/environments/environment';
import Swal from 'sweetalert2';
import { Backlog } from '../../../shared/models/backlog.model';
import { BacklogService } from '../../../shared/services/backlog.service';
import {StoryService} from '../../../shared/services/story.service';
import {Story} from '../../../shared/models/story.model';
import {ActivatedRoute} from '@angular/router';

@Component({
  selector: 'app-backlog',
  templateUrl: './backlog.component.html',
  styleUrls: ['./backlog.component.css']
})
export class BacklogComponent implements OnInit {
  @Input() projetId: number;
  @Input() backlog: Backlog;

  story:Story = new Story();

  constructor(private http: HttpClient, private backlogService: BacklogService , private service: StoryService ,private router: ActivatedRoute) {
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
      res => {
        Swal.fire({
          title: 'Le backlog a été crée avec succes',
          type: 'success',
        });
      },
      err => console.log(err)
    )
  }

  onSubmit(){
    let id = (Number) (this.router.snapshot.paramMap.get("id"))
    this.story.backlogId = id;
    this.service.addStory(this.story)
       .subscribe(res=>{
           Swal.fire({
           title: 'Le user story a été crée avec succes',
           type: 'success',
         });
       },error => console.log(error));
    var model = document.getElementById('exampleModal');
    if(model != null)model.click();
  }

}

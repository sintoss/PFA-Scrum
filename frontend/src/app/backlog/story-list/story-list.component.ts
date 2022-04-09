import {Component, Input, OnInit} from '@angular/core';
import {Story} from '../../shared/models/story.model';
import {StoryService} from '../../shared/services/story.service';
import {BacklogService} from '../../shared/services/backlog.service';
import {ActivatedRoute} from '@angular/router';
import {Backlog} from '../../shared/models/backlog.model';
import {environment} from '../../../environments/environment';
import Swal from 'sweetalert2';
import {HttpClient} from '@angular/common/http';
import {Pager} from '../../shared/models/pager.model';
import {TachmangerService} from '../../shared/services/tachmanger.service';

@Component({
  selector: 'app-story-list',
  templateUrl: './story-list.component.html',
  styleUrls: ['./story-list.component.css']
})
export class StoryListComponent implements OnInit {
  backlog!: Backlog;
  value:any;
  story:Story = new Story();
  storyList$!: any[];
  pager:Pager = new Pager();
  pg:number = 1;
  desc:string = "";
  idproject!:number;
  ImagePath:any;


  constructor(private http: HttpClient, private backlogService: BacklogService ,private service: StoryService, private router: ActivatedRoute
  ,private tachmanger : TachmangerService) {
    this.idproject = (Number)(this.router.snapshot.paramMap.get("id"));
    this.checkIfBacklogExist();
    this.value = new Story();
  }


  ngOnInit(): void {}

  FillList() {
    if(this.backlog !== undefined) {
      this.service.getStoryListByBacklogId(this.backlog.id,this.pg,this.pager.pageSize,this.desc).subscribe(res=>{
        this.storyList$ = (<any>res).newData;
        this.pager = (<any>res).pager;
      },error => console.log(error));
    }
  }

  checkIfBacklogExist(){
    //check if exist
    this.http.get<Backlog>(environment.apiUrl + `/Backlog/${this.idproject}`)
      .subscribe(res=>{
        if(res != null){
             this.backlog = res;
             this.FillList();
        }
      },error => console.log(error));
  }

  createBacklog()
  {
    //try to add if it's not exist
    if(this.backlog === undefined){
      let backlog = new Backlog();
      backlog.dateCreation = new Date();
      backlog.projetId = this.idproject;
      this.http.post<Backlog>(environment.apiUrl + "/backlog/ajouter", backlog).subscribe(
        res => {
          if(res != null){
            this.backlog = res;
            this.FillList();
          }
          Swal.fire({
            title: 'Le backlog a été crée avec succes',
            type: 'success',
          });
        },
        err => console.log(err)
      );
    }
  }

  onSubmit(){
    this.story.backlogId = this.backlog.id;
    this.service.addStory(this.story)
      .subscribe(res=>{
        Swal.fire({
          title: 'Le user story a été crée avec succes',
          type: 'success',
        });
        let model = document.getElementById('exampleModal');
        if(model != null)model.click();
        this.story = new Story();
        this.FillList();
      },error => console.log(error));
  }

 EditModel(s:any){
    this.value=s;
 }

 onUpdating(){
   this.service.updateStory(this.value.id,this.value)
     .subscribe(res=>{
       Swal.fire({
         title: 'Le user story a été modifier avec succes',
         type: 'success',
       });
     },error => console.log(error));
   let model = document.getElementById('exampleModal1');
   if(model != null)model.click();
   this.FillList();
 }

 givepg(pg:number){
    this.pg = pg;
    this.FillList();
 }

 deleteItem(s:any){
   this.value=s;
   Swal.fire({
     title: 'Are you sure?',
     text: "You won't be able to revert this!",
     type: 'warning',
     showCancelButton: true,
     confirmButtonColor: '#3085d6',
     cancelButtonColor: '#d33',
     confirmButtonText: 'Yes, delete it!'
   }).then((result) => {
     if (result.value) {
       this.service.deleteStory(this.value.id).subscribe(res=>{
         Swal.fire(
           'Deleted!',
           'Your file has been deleted.',
           'success'
         );
         this.FillList();
       },error => console.log(error));
     }
   })


 }//end of function

  onOptionsSelected(num:any){
     this.pager.pageSize = num;
     this.FillList();
  }

  onSearchChange(searchValue: any): void {
     this.desc = searchValue.target.value;
     this.FillList();
  }

  AssignUserStory(UserStory:any){
      this.tachmanger.setValue(UserStory);
  }

  GetAvtareUsingUserStory(pathImg:string){
         return `https://localhost:44349/${pathImg}`;
  }

}

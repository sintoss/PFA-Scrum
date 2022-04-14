import { Component, OnInit } from '@angular/core';
import {Pager} from '../../shared/models/pager.model';
import {SprintService} from '../../shared/services/sprint.service';
import Swal from 'sweetalert2';
import {Backlog} from '../../shared/models/backlog.model';
import {environment} from '../../../environments/environment';
import {ActivatedRoute} from '@angular/router';
import {HttpClient} from '@angular/common/http';
import {DetailsprintService} from '../../shared/services/detailsprint.service';

@Component({
  selector: 'app-show-sprint',
  templateUrl: './show-sprint.component.html',
  styleUrls: ['./show-sprint.component.css']
})
export class ShowSprintComponent implements OnInit {

  springList$!:any[];
  pager:Pager = new Pager();
  pg:number = 1;
  lib:string = "";
  sprint:any;
  canIaddorEdit:boolean = false;
  currentsprint:any;
  idproject!:number;
  backlog!: Backlog;

  constructor(private http: HttpClient, public service:SprintService,private router: ActivatedRoute , private sprintstor:DetailsprintService) {
    this.idproject = (Number)(this.router.snapshot.paramMap.get("id"));
    this.checkIfBacklogExist();
  }

  ngOnInit(): void {
  }

  checkIfBacklogExist(){
    //check if exist
    this.http.get<Backlog>(environment.apiUrl + `/Backlog/${this.idproject}`)
      .subscribe(res=>{
        if(res != null){
          this.backlog = res;
          this.FillsprintList();
        }
      },error => console.log(error));
  }

  FillsprintList(){
      if(this.backlog != undefined){
        this.service.getSprints(this.backlog.id,this.pg,this.pager.pageSize,this.lib).subscribe(res=>{
          this.springList$ = (<any>res).data;
          this.pager = (<any>res).pager;
        },error => console.log(error));
      }
  }

  givepg(pg:number){
    this.pg = pg;
    this.FillsprintList();
  }

  onOptionsSelected(num:any){
    this.pg = 1;
    this.pager.pageSize = num;
    this.FillsprintList();
  }


  onSearchChange(searchValue: any): void {
    this.pg = 1;
    this.lib = searchValue.target.value;
    this.FillsprintList();
  }

  assignSprint(item:any){
    this.canIaddorEdit = false;
    this.sprint = item;
  }

  doSomething(){
    this.checkIfBacklogExist()
    let model = document.getElementById('sprintmodel');
    if(model != null)model.click();
  }

  deleteItem(s:any){
    if(s != undefined)
    {
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
        this.service.deleteSprint(s.id).subscribe(res=>{
          if(res != undefined){
            Swal.fire(
              'Deleted!',
              'Your file has been deleted.',
              'success'
            );
            this.FillsprintList();
          }
        },error => console.log(error));
      }
    })

    }
  }//end of function

  Affect(vl:any){
    this.currentsprint = vl;
  }

  clsfrm(){
      let model = document.getElementById('sprintmode2');
      if(model != null) model.click();
  }

  ShowStory(vl:any){
    if(vl != undefined){
      this.service.emitData(false);
      this.sprintstor.setValueOfSprint(vl.id);
    }
  }

}

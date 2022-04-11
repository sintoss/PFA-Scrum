import { Component, OnInit } from '@angular/core';
import {Pager} from '../../shared/models/pager.model';
import {SprintService} from '../../shared/services/sprint.service';
import Swal from 'sweetalert2';

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

  constructor(private service:SprintService) { }

  ngOnInit(): void {
    this.FillsprintList();
  }

  FillsprintList(){
    this.service.getSprints(this.pg,this.pager.pageSize,this.lib).subscribe(res=>{
          this.springList$ = (<any>res).data;
          this.pager = (<any>res).pager;
    },error => console.log(error));
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
    this.FillsprintList();
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

}

import { Component, OnInit } from '@angular/core';
import {Pager} from '../../shared/models/pager.model';
import {SprintService} from '../../shared/services/sprint.service';

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

  CloseFormFunc(vl:any){
      if(vl == true){
         let model = document.getElementById('sprintmodel');
         if(model != null)model.click();
      }
  }

  onSearchChange(searchValue: any): void {
    this.pg = 1;
    this.lib = searchValue.target.value;
    this.FillsprintList();
  }

}

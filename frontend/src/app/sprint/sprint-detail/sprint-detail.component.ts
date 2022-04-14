import {Component, OnInit} from '@angular/core';
import {Pager} from '../../shared/models/pager.model';
import {DetailsprintService} from '../../shared/services/detailsprint.service';
import {SprintService} from '../../shared/services/sprint.service';

@Component({
  selector: 'app-sprint-detail',
  templateUrl: './sprint-detail.component.html',
  styleUrls: ['./sprint-detail.component.css']
})
export class SprintDetailComponent implements OnInit{

  storysprintList$!:any[];
  pager:Pager = new Pager();
  pg:number = 1;
  lib:string = "";
  constructor( public sprint:SprintService ,private service:DetailsprintService) {

      this.sprint.returnSprint().subscribe(res=>{
            if(res == false){
              if(this.service.getValueOfSprint() != null){
                this.FillstorysprintList();
              }
            }
      });

  }

  ngOnInit(): void {}

  FillstorysprintList(){
      this.service.getAllOfstoryOfthisSprint(this.pg,this.pager.pageSize,this.lib).subscribe(res=>{
        //console.log(res);
        this.storysprintList$ = (<any>res).data;
        this.pager = (<any>res).pager;
      },error => console.log(error));
  }

  givepg(pg:number){
    this.pg = pg;
    this.FillstorysprintList();
  }

  onOptionsSelected(num:any){
    this.pg = 1;
    this.pager.pageSize = num;
    this.FillstorysprintList();
  }


  onSearchChange(searchValue: any): void {
    this.pg = 1;
    this.lib = searchValue.target.value;
    this.FillstorysprintList();
  }



}

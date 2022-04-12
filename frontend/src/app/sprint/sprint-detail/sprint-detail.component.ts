import {Component, OnChanges, OnInit, SimpleChanges} from '@angular/core';
import {Pager} from '../../shared/models/pager.model';
import {DetailsprintService} from '../../shared/services/detailsprint.service';

@Component({
  selector: 'app-sprint-detail',
  templateUrl: './sprint-detail.component.html',
  styleUrls: ['./sprint-detail.component.css']
})
export class SprintDetailComponent implements OnInit , OnChanges  {

  storysprintList$!:any[];
  pager:Pager = new Pager();
  pg:number = 1;
  lib:string = "";
  constructor(private service:DetailsprintService) { }

  ngOnInit(): void {}

  FillstorysprintList(){
      this.service.getAllOfstoryOfthisSprint(this.pg,this.pager.pageSize,this.lib).subscribe(res=>{
        console.log(res);
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

  showstory(){
    if(this.service.getValueOfSprint() != null){
      this.FillstorysprintList();
    }
  }

  ngOnChanges(changes: SimpleChanges): void {
    if(this.service.getValueOfSprint() != null){
      this.FillstorysprintList();
    }
  }

}

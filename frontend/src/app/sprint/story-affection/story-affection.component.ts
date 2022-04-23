import {Component, EventEmitter, Input, OnInit, Output, ViewChild} from '@angular/core';
import {Backlog} from '../../shared/models/backlog.model';
import {SprintService} from '../../shared/services/sprint.service';
import {Pager} from '../../shared/models/pager.model';
import Swal from 'sweetalert2';
import {NgForm} from '@angular/forms';
import {expressionType} from '@angular/compiler/src/output/output_ast';

@Component({
  selector: 'app-story-affection',
  templateUrl: './story-affection.component.html',
  styleUrls: ['./story-affection.component.css']
})
export class StoryAffectionComponent implements  OnInit {

  @Input() currentsprint:any;
  @Input() backlog!:Backlog;
  @Output() closeFormWhenAffect = new EventEmitter<boolean>();
  storywithsprintList$!:any[];
  desc:string = "";
  StoryList:number[] = [];


  constructor(public service:SprintService) {

    this.service.returnSprint().subscribe(res=>{
      if(res == true){
        this.Fillist();
      }
    })

  }

  ngOnInit() {
    this.Fillist();
   }


  Fillist(){
    if(this.backlog != undefined){
      this.service.getStorydosnthaveSprint(this.backlog.id,this.desc).subscribe(res=>{
        if(res != undefined){
          this.storywithsprintList$ = res;
        }
      })
    }
  }


  GetAvtareUsingUserStory(pathImg:string){
    return `https://localhost:44349/${pathImg}`;
  }

  onSearchChange(searchValue: any): void {
    this.desc = searchValue.target.value;
    this.Fillist();
  }

  changeStatus(id: number , e : any){
    if(e.target.checked){
       this.StoryList.push(id);
    }else{
      const index: number = this.StoryList.indexOf(id);
      if (index !== -1) {
        this.StoryList.splice(index, 1);
      }
    }
  }

  affect(){

    if(this.currentsprint &&  this.StoryList.length != 0){
        this.service.addMyListOfSotryToSprint(
          {storylist:this.StoryList , sprintid : this.currentsprint.id })
          .subscribe(res => {
            if(res != undefined){
              this.Fillist();
              this.service.emitData(false);
              this.service.emitData2(true);
              this.closeFormWhenAffect.emit(true);
              Swal.fire({
                title : "affection of story to sprint with success",
                type : "success"
              });
            }
          });
      }
    this.StoryList = [];
    this.clearCheckbox();
  }

  clearCheckbox(){
    const chbx = document.getElementsByName("membres[]") ;
    for(let i=0; i < chbx.length; i++) {
      (<HTMLInputElement>chbx[i]).checked = false;
    }
    const zntxt = document.getElementsByName("duree");
    for(let i=0; i < zntxt.length; i++) {
      (<HTMLInputElement>zntxt[i]).value = "";
    }
  }

  ShowError(){
    Swal.fire({
      title : "something went wrong",
      type : "error"
    });
  }

}

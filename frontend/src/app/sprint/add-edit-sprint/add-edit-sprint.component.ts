import {Component, EventEmitter, Input, OnInit, Output, ViewChild} from '@angular/core';
import {NgForm} from '@angular/forms';
import {SprintService} from '../../shared/services/sprint.service';
import Swal from 'sweetalert2';
import {Backlog} from '../../shared/models/backlog.model';
import {environment} from '../../../environments/environment';
import {HttpClient} from '@angular/common/http';
import {ActivatedRoute} from '@angular/router';

@Component({
  selector: 'app-add-edit-sprint',
  templateUrl: './add-edit-sprint.component.html',
  styleUrls: ['./add-edit-sprint.component.css']
})
export class AddEditSprintComponent implements OnInit {

  @ViewChild('f') frm!:NgForm;
  @Input() sprint:any;
  @Input() btnManger!:boolean;
  @Output() refPageancClose = new EventEmitter<boolean>();
  idproject!:number;

  constructor(private http: HttpClient, public service:SprintService,private router: ActivatedRoute) {
    this.checkIfBacklogExist();
  }

  ngOnInit(): void {
  }

  addSprint(){
     this.checkIfBacklogExist().subscribe(res=>{
          if(res != undefined){
            if( this.frm != null){
              this.service.addSprint({BacklogId:res.id,libelle:this.frm.value.Libelle,dateestimeedefin:this.frm.value.dtf})
                .subscribe(r=>{
                  if(r != undefined){
                    Swal.fire({
                      title : "new sprint was added with succes",
                      type : "success"
                    });
                    this.service.emitData(false);
                    this.refPageancClose.emit(true);
                  };
                });
            }else{
              this.showError();
            }
          }
     });
  }

  editSprint(){
    this.checkIfBacklogExist().subscribe(res=>{
          if(res != undefined){
            if(this.sprint != null && this.frm != null){
              this.service.editSprints({Id:this.sprint.id,libelle:this.frm.value.Libelle,dateestimeedefin:this.frm.value.dtf,
                BacklogId:res.id})
                .subscribe(res=>{
                  if(res != undefined){
                    Swal.fire({
                      title : "sprint was updated succes",
                      type : "success"
                    });
                    this.refPageancClose.emit(true);
                  }
                });
            }else{
              this.showError();
            }
          }
    });
  }

  checkIfBacklogExist(){
    //check if exist
    this.idproject = (Number)(this.router.snapshot.paramMap.get("id"));
    return this.http.get<Backlog>(environment.apiUrl + `/Backlog/${this.idproject}`);
  }

  showError(){
    Swal.fire({
      title : "something went wrong",
      type : "error"
    });
  }

}

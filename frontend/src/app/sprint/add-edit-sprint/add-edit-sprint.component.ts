import {Component, EventEmitter, Input, OnInit, Output, ViewChild} from '@angular/core';
import {NgForm} from '@angular/forms';
import {SprintService} from '../../shared/services/sprint.service';
import Swal from 'sweetalert2';

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

  constructor(private service:SprintService) { }

  ngOnInit(): void {
  }

  addSprint(){
      if(this.frm != null){
          this.service.addSprint({libelle:this.frm.value.Libelle,dateestimeedefin:this.frm.value.dtf})
            .subscribe(r=>{
                if(r != undefined){
                  Swal.fire({
                    title : "new sprint was added with succes",
                    type : "success"
                  });
                  this.refPageancClose.emit(true);
                };
            });
      }
  }

  editSprint(){
    if(this.sprint != null && this.frm != null){
       this.service.editSprints({Id:this.sprint.id,libelle:this.frm.value.Libelle,dateestimeedefin:this.frm.value.dtf})
         .subscribe(res=>{
            if(res != undefined){
              Swal.fire({
                title : "sprint was updated succes",
                type : "success"
              });
              this.refPageancClose.emit(true);
            }
         });
    }
  }



}

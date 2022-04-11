import {Component, EventEmitter, OnInit, Output, ViewChild} from '@angular/core';
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
  @Output() CloseForm = new EventEmitter<boolean>();

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
                };
                this.CloseForm.emit(true);
            });
      }
  }

}

import {Component, EventEmitter, OnInit, Output} from '@angular/core';

@Component({
  selector: 'app-termpolicy',
  templateUrl: './termpolicy.component.html',
  styleUrls: ['./termpolicy.component.css']
})
export class TermpolicyComponent implements OnInit {

  @Output() etatEvent = new EventEmitter<Boolean>();
  constructor() { }

  ngOnInit(): void {
  }

  onAcceptepolicy(){
     this.etatEvent.emit(true);

  }

}

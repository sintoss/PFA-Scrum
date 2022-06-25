import { Component, Input, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { JwtService } from '../shared/services/jwt.service';

@Component({
  selector: 'app-sub-header',
  templateUrl: './sub-header.component.html',
  styleUrls: ['./sub-header.component.css']
})
export class SubHeaderComponent implements OnInit {

  roles: Object;

  constructor(public jwtServie: JwtService, private router: Router) {
    this.roles = {};
    Object.assign(this.roles, this.jwtServie.getRoles());
  }

  ngOnInit(): void {
  }

  isScrumMaster(): boolean
  {
    return Object.values(this.roles).indexOf('ScrumMaster') > -1 ? true : false;
  }
}

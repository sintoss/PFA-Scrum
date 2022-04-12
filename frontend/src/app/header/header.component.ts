import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import Swal from 'sweetalert2';
import { JwtService } from '../shared/services/jwt.service';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.css']
})
export class HeaderComponent implements OnInit {

  userInfo = {
    username: "",
    email: "",
    pathImage: "",
    roles: []
  }
  constructor(private router: Router, private jwtService: JwtService) {
    Object.assign(this.userInfo, this.jwtService.getObject());
  }

  ngOnInit(): void {
  }
  openUser()
  {
    document.getElementById("kt_quick_user")?.classList.add("offcanvas-on");
  }
  closeUser()
  {
    document.getElementById("kt_quick_user")?.classList.remove("offcanvas-on");
  }
  logout()
  {
    localStorage.removeItem("autMd");
    Swal.fire({
      title: "Logout avec succes",
      type: "success"
    }).then(value => window.location.reload());
    this.router.navigateByUrl("login");
  }
}

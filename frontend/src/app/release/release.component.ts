import { Component, OnInit } from '@angular/core';
import {ReleaseService} from '../shared/services/release.service';
import {JwtService} from '../shared/services/jwt.service';
import * as FileSaver from 'file-saver';


@Component({
  selector: 'app-release',
  templateUrl: './release.component.html',
  styleUrls: ['./release.component.css']
})
export class ReleaseComponent implements OnInit {
  constructor(private service:ReleaseService , public jwtService: JwtService) {}
  listofrelease:any;
  releaseId!:string;
  afuConfig!:{ multiple: boolean; formatsAllowed: string; uploadAPI: { url: string; params: { page: string; }; }; } ;

  ngOnInit(): void {
      this.service.getRelease().subscribe(res=>{
           this.listofrelease = res;
      });
  }

  setId(nm:any){
     this.releaseId = nm;
     this.afuConfig  =  {
      multiple: false,
      formatsAllowed: ".zip,.rar,.7zip",
      uploadAPI: {
        url:"https://localhost:44349/api/Release",
        params: {
          'page': String(this.releaseId)
        }
      },
    };
  }

   trytodownload(id:number|string){
    this.service.downloadrelease(id).subscribe(res=>{
         FileSaver.saveAs(res, "application.rar");
    })
   }

}

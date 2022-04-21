import {Component, OnInit} from '@angular/core';
import {Story} from '../../shared/models/story.model';
import {StoryService} from '../../shared/services/story.service';
import {BacklogService} from '../../shared/services/backlog.service';
import {ActivatedRoute} from '@angular/router';
import {Backlog} from '../../shared/models/backlog.model';
import {environment} from '../../../environments/environment';
import Swal from 'sweetalert2';
import {HttpClient} from '@angular/common/http';
import {Pager} from '../../shared/models/pager.model';
import {SprintService} from '../../shared/services/sprint.service';
import {TachManagerService} from '../../shared/services/tach-manager.service';
import {ProjetService} from '../../shared/services/projet.service';
import {Projet} from '../../shared/models/projet.model';
import {DetectTeamProjectService} from '../../shared/services/detect-team-project.service';
import {DeveloppeurStoryService} from '../../shared/services/developpeur-story.service';
import {JwtService} from '../../shared/services/jwt.service';

@Component({
  selector: 'app-story-list',
  templateUrl: './story-list.component.html',
  styleUrls: ['./story-list.component.css']
})
export class StoryListComponent implements OnInit {
  backlog!: Backlog;
  value: any;
  story: Story = new Story();
  storyList$!: any[];
  pager: Pager = new Pager();
  pg = 1;
  desc = '';
  idproject!: number;
  ImagePath: any;
  project!:Projet;
  userId!:string;
  storyId!:string;


  // tslint:disable-next-line:max-line-length
  constructor(private http: HttpClient, private backlogService: BacklogService, private service: StoryService, private router: ActivatedRoute
    , private tacheManager: TachManagerService, private sprint: SprintService , public projetService: ProjetService , private teamchange : DetectTeamProjectService
   , private devstory:DeveloppeurStoryService ,  public jwtService: JwtService ) {
    this.idproject = (Number)(this.router.snapshot.paramMap.get('id'));
    this.checkIfBacklogExist();
    this.value = new Story();
    this.teamchange.returnobj().subscribe(res=>{
      if(res){
          this.GetMembre();
      }
    });
    this.sprint.returnSprint2().subscribe(res=>{
      if(res){
        this.FillList();
      }
    });
  }


  ngOnInit(): void {
    this.GetMembre();
  }

  GetMembre(){
    this.projetService.getProjetDetail(this.idproject).subscribe(
      res => {
        this.project = res;
      }
    );
  }

  // tslint:disable-next-line:typedef
  FillList() {
    if (this.backlog !== undefined) {
      this.service.getStoryListByBacklogId(this.backlog.id, this.pg, this.pager.pageSize, this.desc).subscribe(res => {
        this.storyList$ = (res as any).newData;
        this.pager = (res as any).pager;
      }, error => console.log(error));
    }
  }

  // tslint:disable-next-line:typedef
  checkIfBacklogExist() {
    // check if exist
    this.http.get<Backlog>(environment.apiUrl + `/Backlog/${this.idproject}`)
      .subscribe(res => {
        if (res != null) {
          this.backlog = res;
          this.backlogService.setBackId(this.backlog.id);
          this.FillList();
          this.sprint.emitData3(true);
        }
      }, error => console.log(error));
  }

  // tslint:disable-next-line:typedef
  createBacklog() {
    // try to add if it's not exist
    if (this.backlog === undefined) {
      const backlog = new Backlog();
      backlog.dateCreation = new Date();
      backlog.projetId = this.idproject;
      this.http.post<Backlog>(environment.apiUrl + '/backlog/ajouter', backlog).subscribe(
        res => {
          if (res != null) {
            this.backlog = res;
            this.backlogService.setBackId(this.backlog.id);
            this.FillList();
            this.sprint.emitData3(true);
          }
          Swal.fire({
            title: 'Le backlog a été crée avec succes',
            type: 'success',
          });
        },
        err => console.log(err)
      );
    }
  }

  // tslint:disable-next-line:typedef
  onSubmit() {
    this.story.backlogId = this.backlog.id;
    this.service.addStory(this.story)
      .subscribe(() => {
        Swal.fire({
          title: 'Le user story a été crée avec succes',
          type: 'success',
        });
        this.sprint.emitData(true);
        this.sprint.emitData3(true);
        const model = document.getElementById('exampleModal');
        if (model != null) {
          model.click();
        }
        this.story = new Story();
        this.FillList();
      }, error => console.log(error));
  }

  // tslint:disable-next-line:typedef
  EditModel(s: any) {
    this.value = s;
  }

  // tslint:disable-next-line:typedef
  onUpdating() {
    this.service.updateStory(this.value.id, this.value)
      .subscribe(res => {
          this.FillList();
          Swal.fire({
            title: 'Le user story a été modifier avec succes',
            type: 'success',
          });
      }, error => console.log(error));
    const model = document.getElementById('exampleModal1');
    if (model != null) {
      model.click();
    }
  }

  // tslint:disable-next-line:typedef
  givepg(pg: number) {
    this.pg = pg;
    this.FillList();
  }

  // tslint:disable-next-line:typedef
  deleteItem(s: any) {
    this.value = s;
    Swal.fire({
      title: 'Are you sure?',
      text: 'You won\'t be able to revert this!',
      type: 'warning',
      showCancelButton: true,
      confirmButtonColor: '#3085d6',
      cancelButtonColor: '#d33',
      confirmButtonText: 'Yes, delete it!'
    }).then((result) => {
      if (result.value) {
        this.service.deleteStory(this.value.id).subscribe(res => {
          Swal.fire(
            'Deleted!',
            'Your file has been deleted.',
            'success'
          );
          this.sprint.emitData(true);
          this.FillList();
        }, error => console.log(error));
      }
    });


  }// end of function

  // tslint:disable-next-line:typedef
  onOptionsSelected(num: any) {
    this.pg = 1;
    this.pager.pageSize = num;
    this.FillList();
  }

  onSearchChange(searchValue: any): void {
    this.pg = 1;
    this.desc = searchValue.target.value;
    this.FillList();
  }

  // tslint:disable-next-line:typedef
  AssignUserStory(storyId: number) {
    this.tacheManager.sendClickEvent(storyId);
  }

  // tslint:disable-next-line:typedef
  GetAvtareUsingUserStory(pathImg: string) {
    return `https://localhost:44349/${pathImg}`;
  }

  changeStatus(id: string , e : any){
    if(e.target.checked){
         this.userId = id;
    }
  }

  assignStoryId(str:string){
    this.storyId = str;
  }

  addstorytomembre(){
      if(this.userId && this.storyId){
          //add story to dev
          this.devstory.insertDevStory({developpeurId:this.userId,storyId : this.storyId}).subscribe(res=>{
            if(res){
                 this.FillList();
              this.sprint.emitData(true);
            }
          })
      }
      let model = document.getElementById('lgmodel');
      if(model != null) model.click();
      this.userId = "";
      this.clearRadio();
  }

  clearRadio(){
    const chbx = document.getElementsByName("rbutton") ;
    for(let i=0; i < chbx.length; i++) {
      (<HTMLInputElement>chbx[i]).checked = false;
    }
  }

}

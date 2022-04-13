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
import {TachManagerService} from '../../shared/services/tach-manager.service';

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


  // tslint:disable-next-line:max-line-length
  constructor(private http: HttpClient, private backlogService: BacklogService, private service: StoryService, private router: ActivatedRoute, private TacheManager: TachManagerService) {
    this.idproject = (Number)(this.router.snapshot.paramMap.get('id'));
    this.checkIfBacklogExist();
    this.value = new Story();
  }


  ngOnInit(): void {
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
          this.FillList();
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
            this.FillList();
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
      .subscribe(() => {
        Swal.fire({
          title: 'Le user story a été modifier avec succes',
          type: 'success',
        });
      }, error => console.log(error));
    const model = document.getElementById('exampleModal1');
    if (model != null) {
      model.click();
    }
    this.FillList();
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
        this.service.deleteStory(this.value.id).subscribe(() => {
          Swal.fire(
            'Deleted!',
            'Your file has been deleted.',
            'success'
          );
          this.FillList();
        }, error => console.log(error));
      }
    });


  }// end of function

  // tslint:disable-next-line:typedef
  onOptionsSelected(num: any) {
    this.pager.pageSize = num;
    this.FillList();
  }

  onSearchChange(searchValue: any): void {
    this.desc = searchValue.target.value;
    this.FillList();
  }

  // tslint:disable-next-line:typedef
  AssignUserStory(storyId: number) {
    this.TacheManager.sendClickEvent(storyId);
  }

  // tslint:disable-next-line:typedef
  GetAvtareUsingUserStory(pathImg: string) {
    return `https://localhost:44349/${pathImg}`;
  }

}

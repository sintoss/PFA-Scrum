import {Component, Input, OnInit} from '@angular/core';
import {TachManagerService} from '../../shared/services/tach-manager.service';
import {TacheService} from '../../shared/services/tache.service';
import {TacheModel} from '../../shared/models/tache.model';
import {Etat} from '../../shared/models/Etat.model';
import {Story} from '../../shared/models/story.model';
import {StoryService} from '../../shared/services/story.service';
import {Subscription} from 'rxjs';
import Swal from 'sweetalert2';
import {Pager} from '../../shared/models/pager.model';
import {SearchService} from '../../shared/services/search.service';
import {JwtService} from '../../shared/services/jwt.service';


@Component({
  selector: 'app-tache-item',
  templateUrl: './tache-item.component.html',
  styleUrls: ['./tache-item.component.css']
})
export class TacheItemComponent implements OnInit {
  clickEventSubscription: Subscription;
  storyTaches: TacheModel[];
  story: Story[];
  tacheForm!: TacheModel;
  editTache: TacheModel;
  pager: Pager = new Pager();
  pg = 1;
  @Input() desc!: string;

  // tslint:disable-next-line:max-line-length
  constructor(private tacheService: TacheService, private tacheManager: TachManagerService, private storyService: StoryService, private searchService: SearchService ,  public jwtService: JwtService) {
    this.clickEventSubscription = this.tacheManager.getClickEvent().subscribe(() => {
      this.getStoryTaches();
      this.storyTaches = [];
    });
    this.storyTaches = new Array<TacheModel>();
    this.story = new Array<Story>();
    this.editTache = new TacheModel();
    this.searchService.getClickEvent().subscribe(res => {
      if (res) {
        this.pg = 1;
        this.getStoryTaches();
      }
    });
  }

  ngOnInit(): void {
    this.getStoryList();
  }


  etatCasting(etat: boolean): string {
    return etat ? "Done" : "ToDo";
  }

  // tslint:disable-next-line:typedef
  getStoryList() {
    this.storyService.getStoryList().subscribe(
      response => this.story.push(...response));
  }

  // tslint:disable-next-line:typedef
  getStoryTaches() {

    this.tacheService.getStoryTaches(this.tacheManager.storyId, this.pg, this.pager.pageSize, this.desc
    ).subscribe(
      (res: any) => {
        this.storyTaches = (res as any).data;
        this.pager = (res as any).pager;
      });
  }

  // tslint:disable-next-line:typedef
  editForm(tache: TacheModel) {
    this.tacheForm = tache;
  }

  // tslint:disable-next-line:typedef
  onEdit() {
    this.tacheService.updateTache(this.tacheForm.id, this.tacheForm).subscribe(
      () => {
        Swal.fire({
          title: 'Le user story a été modifier avec succes',
          type: 'success',
        });
        this.storyTaches = [];
        this.getStoryTaches();
      }, error => {
        console.log(error);
      }
    );
  }

  // tslint:disable-next-line:typedef
  deleteTache(tache: number) {
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
        this.tacheService.deleteTache(tache).subscribe(() => {
          Swal.fire(
            'Deleted!',
            'Your file has been deleted.',
            'success'
          );
          this.storyTaches = [];
          this.getStoryTaches();
        }, error => console.log(error));
      }
    });
  }

  // tslint:disable-next-line:typedef
  givepg(pg: number) {
    this.pg = pg;
    this.getStoryTaches();
  }

  // tslint:disable-next-line:typedef
  onOptionsSelected(num: any) {
    this.pg = 1;
    this.pager.pageSize = num;
    this.getStoryTaches();
  }


}

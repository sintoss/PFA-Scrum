import {Component, OnInit} from '@angular/core';
import {TacheService} from '../../shared/services/tache.service';
import {TacheModel} from '../../shared/models/tache.model';
import {FormControl, FormGroup} from '@angular/forms';
import {Story} from '../../shared/models/story.model';
import {StoryService} from '../../shared/services/story.service';
import Swal from 'sweetalert2';
import {TachManagerService} from '../../shared/services/tach-manager.service';
import {JwtService} from '../../shared/services/jwt.service';
import {BacklogService} from '../../shared/services/backlog.service';


@Component({
  selector: 'app-tache-form',
  templateUrl: './tache-form.component.html',
  styleUrls: ['./tache-form.component.css']
})
export class TacheFormComponent implements OnInit {
  registerForm!: FormGroup;
  story: any;
  _tache: TacheModel = new TacheModel();

  private backId: any;

  readonly modules = {
    toolbar: [
      ['bold', 'italic', 'underline', 'strike'],        // toggled buttons
      ['blockquote', 'code-block'],
  
      [{ 'header': [1, 2, 3, 4, 5, 6, false] }],
      [{ 'list': 'ordered'}, { 'list': 'bullet' }],
      [{ 'indent': '-1'}, { 'indent': '+1' }],          // outdent/indent
      [{ 'direction': 'rtl' }]                         // text direction
    ]
  };

  constructor(private tacheService: TacheService, private storyService: StoryService, public tacheManager: TachManagerService,
              private backLogService: BacklogService) {

  }

  onSubmit() {
    this._tache.libelle = this.registerForm.value.Libelle;
    this._tache.description = this.registerForm.value.Description;
    this._tache.dateCreation = new Date();
    this._tache.dateDerniereModification = new Date();
    this._tache.storyId = this.tacheManager.storyId;
    this.tacheService.postTaches(this._tache).subscribe(
      () => {
        Swal.fire({
          title: 'la tâche a été ajoutée avec succès',
          type: 'success',
        });
        this.tacheManager.sendClickEvent(this._tache.storyId);
      }, error => console.log(error));
    this.registerForm.reset();
    // this.getStoryTaches(this.registerForm.value.storyId);
  }

  /* getStoryTaches(storyId: number) {
     this.tacheService.getStoryTaches(storyId).subscribe(
       response => this.storyTaches.push(...response),
       error => console.log(error));
   }*/

  ngOnInit(): void {
    this.initForm();
    this.getBackLogId();
  }

  initForm() {
    this.registerForm = new FormGroup({
      //storyId: new FormControl(),
      Libelle: new FormControl(),
      Description: new FormControl()
    });
  }

  getBackLogId() {
    this.backLogService.backId.subscribe(value => {
        this.backId = value;
      }
    );
  }

  getStoryList() {
    this.story = [];
    this.storyService.getAllStoriesById(this.backId).subscribe(
      response => {
        console.log(response);
        this.story = response;
      }
    );
  }

  closeModal() {
    this.registerForm.reset();
  }

}

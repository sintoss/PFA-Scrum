import {Component, OnInit} from '@angular/core';
import {TacheService} from '../../shared/services/tache.service';
import {TacheModel} from '../../shared/models/tache.model';
import {FormControl, FormGroup} from '@angular/forms';
import {Story} from '../../shared/models/story.model';
import {StoryService} from '../../shared/services/story.service';
import Swal from 'sweetalert2';
import {TachManagerService} from '../../shared/services/tach-manager.service';


@Component({
  selector: 'app-tache-form',
  templateUrl: './tache-form.component.html',
  styleUrls: ['./tache-form.component.css']
})
export class TacheFormComponent implements OnInit {
  registerForm!: FormGroup;
  story: Story[];
  _tache: TacheModel = new TacheModel();

  // private storyTaches: TacheModel[];

  constructor(private tacheService: TacheService, private storyService: StoryService, private tacheManager: TachManagerService) {
    this.story = new Array<Story>();
    // this.storyTaches = new Array<TacheModel>();
  }

  onSubmit() {
    this._tache.libelle = this.registerForm.value.Libelle;
    this._tache.dateCreation = new Date();
    this._tache.dateDerniereModification = new Date();
    this._tache.storyId = this.registerForm.value.storyId;
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
  }

  initForm() {
    this.registerForm = new FormGroup({
      storyId: new FormControl(),
      Libelle: new FormControl()
    });
  }

  getStoryList() {
    this.story = [];
    this.storyService.getStoryList().subscribe(
      response => this.story.push(...response));
  }

  closeModal() {
    this.registerForm.reset();
  }

}

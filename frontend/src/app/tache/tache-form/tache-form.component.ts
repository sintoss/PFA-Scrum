import {Component, OnInit, ViewChild} from '@angular/core';
import {TacheService} from '../../shared/services/tache.service';
import {TacheModel} from '../../shared/models/tache.model';
import {FormControl, FormGroup} from '@angular/forms';


@Component({
  selector: 'app-tache-form',
  templateUrl: './tache-form.component.html',
  styleUrls: ['./tache-form.component.css']
})
export class TacheFormComponent implements OnInit {
  registerForm: FormGroup;

  readonly story: any = [
    {
      'id': 1,
      'description': 'story desc',
      'dateCreation': '2022-04-03T00:00:00',
      'dateDerniereModification': null,
      'commentaire': null,
      'backlogId': 1,
      'backlog': null,
      'taches': null,
      'sprintStories': null,
      'deloppeurStories': null,
      'testeurStories': null
    },
    {
      'id': 2,
      'description': 'story desc',
      'dateCreation': '2022-04-03T00:00:00',
      'dateDerniereModification': null,
      'commentaire': null,
      'backlogId': 1,
      'backlog': null,
      'taches': null,
      'sprintStories': null,
      'deloppeurStories': null,
      'testeurStories': null
    }
  ];

  constructor(private addTache: TacheService) {
  }

  onSubmit() {
    this.addTache.postTaches(new TacheModel(
      this.registerForm.value.Libelle,
      new Date(),
      this.registerForm.value.storyId)).subscribe(
      response => console.log(response),
      error => console.log(error)
    );
    this.registerForm.reset();
  }

  ngOnInit(): void {
    this.initForm();
  }

  initForm() {
    this.registerForm = new FormGroup({
      storyId: new FormControl(),
      Libelle: new FormControl()
    });
  }

}

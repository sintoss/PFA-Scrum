import { Component, OnInit } from '@angular/core';
import { Story } from 'src/app/shared/models/story.model';
import { CdkDragDrop, moveItemInArray, transferArrayItem } from '@angular/cdk/drag-drop';
import { ActivatedRoute } from '@angular/router';
import {SprintService} from '../../shared/services/sprint.service';
import { StoryView } from 'src/app/shared/models/story-view.model';
import { JwtService } from 'src/app/shared/services/jwt.service';
import { DeveloppeurStory } from 'src/app/shared/models/developpeurStory.model';
import { TacheModel } from 'src/app/shared/models/tache.model';
import { TacheService } from 'src/app/shared/services/tache.service';
import { StoryService } from 'src/app/shared/services/story.service';
import Swal from 'sweetalert2';
import { Sprint } from 'src/app/shared/models/sprint.model';

@Component({
  selector: 'app-board',
  templateUrl: './board.component.html',
  styleUrls: ['./board.component.css']
})
export class BoardComponent implements OnInit {

  stories: Array<Story[]>;
  sprintId: number;
  storiesRemain: number;
  readonly etats = [0,1,2,3];

  constructor(private router: ActivatedRoute, private sprintService: SprintService, public jwtService: JwtService, private tacheService: TacheService, private storyService: StoryService)
  {
    this.sprintId = (Number)(this.router.snapshot.paramMap.get('sprintId'));
    this.stories = [new Array<Story>(), new Array<Story>(), new Array<Story>(), new Array<Story>(), new Array<Story>()];
    this.storiesRemain = 0;
  }
  ngOnInit(): void {
    this.sprintService.getMySprint(this.sprintId).subscribe(
      res => {
        res.forEach((item) => {
          if(this.etats.includes(item.etat)) this.storiesRemain++
          this.stories[item.etat].push(item);
        });
        console.log(this.storiesRemain);
      }
    );
  }

  onDrop(event: CdkDragDrop<Story[]>)
  {
    if(event.previousContainer === event.container) {
      moveItemInArray(
        event.container.data,
        event.previousIndex,
        event.currentIndex
      )
    } else {
      transferArrayItem(
        event.previousContainer.data,
        event.container.data,
        event.previousIndex,
        event.currentIndex
      );
      if(parseInt(event.container.id) === 1 && parseInt(event.previousContainer.id) === 2) {
        Swal.fire({
          title: "Confirmation!!",
          text: "ajouter un commentaire pour justifier",
          type: 'warning',
          input: "textarea",
          inputPlaceholder: "Entrer votre commentaire...",
          showCancelButton: true,
          cancelButtonText: "Annuler",
          confirmButtonText: "Confirmer",
          confirmButtonColor: '#3085d6',
          cancelButtonColor: '#d33',
          preConfirm: (value) => {
            if(value === "" || value == null) {
              Swal.showValidationMessage("Vous devez entrer un commentaire");
            }
          }
        }).then((res) => {
          if(res.value) {
            let story = new StoryView(event.container.data[event.currentIndex]);
            story.etat = parseInt(event.container.id);
            story.commentaire = res.value;
            this.storyService.storyStateChanged(story.id, story).subscribe(
              res => {
                event.container.data[event.currentIndex].etat = res.etat;
                event.container.data[event.currentIndex].commentaire = res.commentaire;
                console.log(event.container.data[event.currentIndex]);
                Swal.fire(
                  'Changée!',
                  'Etat changé avec succes',
                  'success'
                );
              },
              err => {
                transferArrayItem(
                  event.container.data,
                  event.previousContainer.data,
                  event.currentIndex,
                  event.previousIndex
                );
              }
            );
          } else {
            transferArrayItem(
              event.container.data,
              event.previousContainer.data,
              event.currentIndex,
              event.previousIndex
            );
          }
        })
      } else {
        Swal.fire({
          title: "Confirmation!!",
          type: 'warning',
          showCancelButton: true,
          cancelButtonText: "Annuler",
          confirmButtonText: "Confirmer",
          confirmButtonColor: '#3085d6',
          cancelButtonColor: '#d33',
        }).then((res) => {
          if(res.value) {
            console.log(event.container.data[event.currentIndex]);
            let story = new StoryView(event.container.data[event.currentIndex]);
            story.etat = parseInt(event.container.id);
            if(parseInt(event.container.id) === 1 && parseInt(event.previousContainer.id) === 0) {
              story.dateDebut = new Date();
              story.datePrevuFin = new Date();
              story.datePrevuFin.setDate(story.dateDebut.getDate() + story.duree);
            }
            if(parseInt(event.container.id) === 2 && parseInt(event.previousContainer.id) === 1) {
              story.dateFin = new Date();
            }
            //console.log(story);
            this.storyService.storyStateChanged(story.id, story).subscribe(
              res => {
                event.container.data[event.currentIndex].etat = res.etat;
                if(parseInt(event.container.id) === 1 && parseInt(event.previousContainer.id) === 0) {
                  event.container.data[event.currentIndex].dateDebut = res.dateDebut;
                  event.container.data[event.currentIndex].datePrevuFin = res.datePrevuFin;
                }
                if(parseInt(event.container.id) === 2 && parseInt(event.previousContainer.id) === 1) {
                  event.container.data[event.currentIndex].dateFin = res.dateFin;
                }
                if(parseInt(event.container.id) === 4 && parseInt(event.previousContainer.id) === 3) {
                  this.storiesRemain--;
                }
                Swal.fire(
                  'Changée!',
                  'Etat changé avec succes',
                  'success'
                )
                if(this.storiesRemain === 0)
                {
                  let sprint = new Sprint();
                  this.sprintService.completeSprint(this.sprintId, sprint).subscribe(
                    res => {
                      event.container.data[event.currentIndex].sprintStories[0].sprint.finDeSprint = true;
                      Swal.fire(
                        'Completé!',
                        'Le Sprint a ete completé',
                        'success'
                      )
                    }
                  )
                }
              },
              err => {
                transferArrayItem(
                  event.container.data,
                  event.previousContainer.data,
                  event.currentIndex,
                  event.previousIndex
                );
              }
            );
          } else {
            transferArrayItem(
              event.container.data,
              event.previousContainer.data,
              event.currentIndex,
              event.previousIndex
            );
          }
        })
      }
    }
  }
  toggleTache(btnElt: HTMLElement, divElt: HTMLElement)
  {
    divElt.classList.toggle("toggleDiv");
    btnElt.classList.toggle("toggleBtn");
  }
  checkTaches(item: Story)
  {
    
    if(item.taches.filter(t => t.etat === false).length > 0) {
      return true;
    }
    return false;
  }
  checkDelai(datePrevuFin: Date): boolean
  {
    if(datePrevuFin !== undefined && new Date(datePrevuFin).getDate() < new Date().getDate()) {
      console.log(true);
      return true;
    }
    return false;
  }
  completeTache(tache: TacheModel)
  {
    this.tacheService.completeTache(tache).subscribe(
      res => {
        tache.etat = true;
        Swal.fire({
          title: 'Completée!',
          text: 'Tache completée avec succes',
          type: "success",
          customClass: {
            container: 'appear'
          }
        });
      },
      err => console.log(err)
    )
  }
  toggleComment(btnElt: HTMLElement, divElt: HTMLElement)
  {
    divElt.classList.toggle("toggleComment");
  }
}

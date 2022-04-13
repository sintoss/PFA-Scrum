import {Component, Input, OnInit} from '@angular/core';
import {SearchService} from '../../shared/services/search.service';

@Component({
  selector: 'app-tache-list',
  templateUrl: './tache-list.component.html',
  styleUrls: ['./tache-list.component.css']
})
export class TacheListComponent implements OnInit {
  searchElement!: string;

  constructor(private searchService: SearchService) {

  }

  ngOnInit(): void {
  }

  onSearchChange(searchValue: any): void {
    this.searchElement = searchValue.target.value;
    this.searchService.sendClickEvent(true);
  }

}

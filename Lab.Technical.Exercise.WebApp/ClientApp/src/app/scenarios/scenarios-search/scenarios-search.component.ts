import { Component, OnInit } from '@angular/core';
import { IScenario } from '../../core/models/Scenario';

@Component({
  selector: 'app-scenarios-search',
  templateUrl: './scenarios-search.component.html',
  styleUrls: ['./scenarios-search.component.css']
})
export class ScenariosSearchComponent implements OnInit {
  searchString: string = '';
  searchByuserIdResult: IScenario;
  constructor() { }

  ngOnInit(): void {
  }

  onSeachByUserId(value: IScenario): void {
    this.searchByuserIdResult = value;
    this.searchString = '';
  }
  onSeachByCreationDateRange(value: string): void {
    this.searchByuserIdResult = undefined;
    this.searchString = value;
  }

}

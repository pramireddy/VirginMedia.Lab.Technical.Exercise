import { Component, Input, OnInit } from '@angular/core';
import { IScenario } from '../../core/models/Scenario';

@Component({
  selector: 'app-scenario-details',
  templateUrl: './scenario-details.component.html',
  styleUrls: ['./scenario-details.component.css']
})
export class ScenarioDetailsComponent implements OnInit {

  @Input() scenario: IScenario;
  displayedColumns: string[] = ['key', 'value'];
  dataSource: IScenario;
  hideHeader: boolean = true;

  constructor() { }

  ngOnInit(): void {
    this.dataSource = this.scenario
  }
  public orderByKey(a) {
    return a.key;
  }

}

import { AfterViewInit, Component, OnInit, ViewChild } from '@angular/core';
import { MatPaginator } from '@angular/material/paginator';
import { MatTableDataSource } from '@angular/material/table';
import { MatSort } from '@angular/material/sort';
import { IScenario } from '../../core/models/Scenario';
import { ReactiveFormsModule } from '@angular/forms';
import { LoggerService, ScenariosService } from '../../core/services';

@Component({
  selector: 'app-scenarios-summary',
  templateUrl: './scenarios-summary.component.html',
  styleUrls: ['./scenarios-summary.component.css']
})
export class ScenariosSummaryComponent implements AfterViewInit, OnInit {

  displayedColumns: string[] = ['scenarioId', 'name', 'surname', 'forename', 'userId', 'sampleDate', 'creationDate', 'numberOfMonths', 'marketId', 'networkLayerId'];
  dataSource: IScenario[] = [];
  filteredDataSource = new MatTableDataSource<IScenario>();
  @ViewChild(MatSort) sort: MatSort;
  @ViewChild(MatPaginator) paginator: MatPaginator;
  filter: string = '';

  constructor(private scenarioService: ScenariosService, private logger: LoggerService) {
  }

  ngOnInit(): void {
    this.fectechScenarios();
  }

  private fectechScenarios() {
    this.scenarioService.fetchScenarios()
      .subscribe(
        {
          next: (result: IScenario[]) => {
            this.dataSource = result;
            this.filteredDataSource.data = this.dataSource;
            this.filteredDataSource = new MatTableDataSource(this.dataSource);
            this.filteredDataSource.paginator = this.paginator;
            this.filteredDataSource.sort = this.sort;
          },
          error: (error: any) => {
            this.logger.error("Failed to Fetch Scenarios" + error);
          },
          complete: () => {
            this.logger.trace("Fetch Scenarios succcess");
          }
        }
      );
  }

  ngAfterViewInit(): void {
    this.filteredDataSource.paginator = this.paginator;
    this.filteredDataSource.sort = this.sort;
  }

  applyFilter() {
    if (!this.dataSource)
      return;
    let lowerFilter = this.filter.toLowerCase();
    this.filteredDataSource.data = this.dataSource.filter(x =>
      this.filter === '' ||
      (x.scenarioId.toString().toLowerCase().includes(lowerFilter) ||
        // x.name.toLowerCase().includes(lowerFilter) ||
        x.surname.toLowerCase().includes(lowerFilter) ||
        x.forename.toLowerCase().includes(lowerFilter) ||
        x.userId.toLowerCase().includes(lowerFilter))
    );
  }

  clearFilter() {
    this.filter = '';
    this.applyFilter();
  }
}
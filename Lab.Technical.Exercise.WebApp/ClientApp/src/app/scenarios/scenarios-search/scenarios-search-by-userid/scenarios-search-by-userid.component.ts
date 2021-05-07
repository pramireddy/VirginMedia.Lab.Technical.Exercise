import { Component, EventEmitter, OnInit, Output } from '@angular/core';
import { FormBuilder, FormGroup, Validators, FormControl } from '@angular/forms';
import { LoggerService, ScenariosService } from '../../../core/services'
import { IScenario } from '../../../core/models/Scenario'

@Component({
  selector: 'app-scenarios-search-by-userid',
  templateUrl: './scenarios-search-by-userid.component.html',
  styleUrls: ['./scenarios-search-by-userid.component.css']
})
export class ScenariosSearchByUseridComponent implements OnInit {
  @Output() notify = new EventEmitter<IScenario>();
  searchForm: FormGroup;
  constructor(private formBuilder: FormBuilder, private scenarioService: ScenariosService, private logger: LoggerService) { }

  ngOnInit(): void {
    this.searchForm = this.formBuilder.group({
      fileName: new FormControl('', Validators.required),
    });
  }

  search(formValues: { fileName: any; }) {
    let userId = formValues.fileName;
    this.fectechScenariosByUserId(userId)
  }

  private fectechScenariosByUserId(userId: string) {
    this.scenarioService.fetchScenariosByUserId(userId)
      .subscribe(
        {
          next: (result: IScenario) => {
            this.notify.emit(result);
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
}

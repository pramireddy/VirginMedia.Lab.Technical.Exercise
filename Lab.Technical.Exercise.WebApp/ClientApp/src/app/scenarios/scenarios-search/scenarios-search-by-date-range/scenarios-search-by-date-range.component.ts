import { Component, EventEmitter, OnInit, Output } from '@angular/core';
import { FormBuilder, FormGroup, FormControl, Validators } from '@angular/forms';

@Component({
  selector: 'app-scenarios-search-by-date-range',
  templateUrl: './scenarios-search-by-date-range.component.html',
  styleUrls: ['./scenarios-search-by-date-range.component.css']
})
export class ScenariosSearchByDateRangeComponent implements OnInit {
  @Output() notify = new EventEmitter<string>();
  searchForm: FormGroup;
  validDates: boolean = false;
  startDate: Date;
  endDate: Date;
  constructor(private formBuilder: FormBuilder) { }
  ngOnInit(): void {
    this.searchForm = this.formBuilder.group({
      startDate: new FormControl('', Validators.required),
      endDate: new FormControl('', Validators.required),
    });
  }

  search(formValues: { startDate: Date; endDate: Date; }) {
    this.startDate = formValues.startDate;
    this.endDate = formValues.endDate;

    this.validDates = this.compareDates(this.startDate, this.endDate);
    if (this.validDates) {
      // TO DO: Call service at https://localhost:5001/api/scenarios/ByCreationDateRange?dateFrom=2013-01-01&dateTo=2020-11-15
      // and emit result to parent control
      this.notify.emit(`From Date: ${this.startDate.toLocaleString()} and To Date: ${this.endDate.toLocaleString()}`);
    }

  }
  compareDates(startDate: Date, endDate: Date) {
    return (startDate <= endDate);
  }
}

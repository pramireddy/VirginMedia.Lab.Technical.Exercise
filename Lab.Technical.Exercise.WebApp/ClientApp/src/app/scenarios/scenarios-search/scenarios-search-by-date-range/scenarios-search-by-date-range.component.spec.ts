import { TestBed, async, ComponentFixture } from '@angular/core/testing';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { HttpClientTestingModule } from '@angular/common/http/testing';
import { ReactiveFormsModule } from '@angular/forms';

import { ScenariosSearchByDateRangeComponent } from './scenarios-search-by-date-range.component';
import { MaterialModule } from '../../../material.module';

describe('ScenariosSearchByDateRangeComponent', () => {
  let component: ScenariosSearchByDateRangeComponent;
  let fixture: ComponentFixture<ScenariosSearchByDateRangeComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      imports: [
        ReactiveFormsModule,
        BrowserAnimationsModule,
        MaterialModule,
        HttpClientTestingModule
      ],
      declarations: [ ScenariosSearchByDateRangeComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ScenariosSearchByDateRangeComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

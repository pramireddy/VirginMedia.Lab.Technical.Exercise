import { TestBed, async, ComponentFixture } from '@angular/core/testing';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { HttpClientTestingModule } from '@angular/common/http/testing';
import { ReactiveFormsModule, FormsModule } from '@angular/forms';

import { MaterialModule } from '../../material.module';
import { ScenariosSummaryComponent } from './scenarios-summary.component';
import { AppService, LoggerService, ScenariosService } from '../../core/services';

describe('ScenariosSummaryComponent', () => {
  let component: ScenariosSummaryComponent;
  let fixture: ComponentFixture<ScenariosSummaryComponent>;
  let service: ScenariosService;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      imports:[
        ReactiveFormsModule,
        BrowserAnimationsModule,
        FormsModule,
        MaterialModule,
        HttpClientTestingModule
      ],
      declarations: [ ScenariosSummaryComponent ],
      providers: [
        ScenariosService,
        LoggerService,
        AppService
      ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ScenariosSummaryComponent);
    component = fixture.componentInstance;
    service = TestBed.inject(ScenariosService)
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

import { TestBed, async, ComponentFixture } from '@angular/core/testing';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { HttpClientTestingModule } from '@angular/common/http/testing';
import { ReactiveFormsModule } from '@angular/forms';
import { MaterialModule } from '../../../material.module';

import { AppService, ScenariosService } from '../../../core/services'
import { ScenariosSearchByUseridComponent } from './scenarios-search-by-userid.component';

describe('ScenariosSearchByUseridComponent', () => {
  let component: ScenariosSearchByUseridComponent;
  let fixture: ComponentFixture<ScenariosSearchByUseridComponent>;
  let service: ScenariosService;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      imports: [
        ReactiveFormsModule,
        BrowserAnimationsModule,
        MaterialModule,
        HttpClientTestingModule
      ],
      declarations: [ScenariosSearchByUseridComponent],
      providers: [
        ScenariosService,
        AppService
      ]
    })
      .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ScenariosSearchByUseridComponent);
    component = fixture.componentInstance;
    service = TestBed.inject(ScenariosService)
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
  it('should display search by userid form', () => {
    expect(fixture.nativeElement.querySelector('#searchByUserId')).toBeTruthy();
  });

  it('should call scenariosservice.fetchScenariosByUserId when submitting form', () => {
    let serviceSpy = spyOn(service, 'fetchScenariosByUserId').and.callThrough();
    let searchSpy = spyOn(component, 'search').and.callThrough();

    let inputValue: string = 'testUserId';
    let input = fixture.nativeElement.querySelector('input');

    input.value = inputValue;
    input.dispatchEvent(new Event('input'));

    fixture.detectChanges();

    fixture.nativeElement.querySelector('#searchButton').click();

    expect(searchSpy).toHaveBeenCalled();
    expect(serviceSpy).toHaveBeenCalledWith(inputValue);
  });

  it('should not call search function if form is invalid', () => {
    let searchSpy = spyOn(component, 'search').and.callThrough();

    fixture.nativeElement.querySelector('#searchButton').click();
    expect(searchSpy).not.toHaveBeenCalled();
  });
});

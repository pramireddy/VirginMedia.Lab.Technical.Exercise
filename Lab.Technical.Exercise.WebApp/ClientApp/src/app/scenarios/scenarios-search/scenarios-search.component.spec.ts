import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ScenariosSearchComponent } from './scenarios-search.component';

describe('ScenariosSearchComponent', () => {
  let component: ScenariosSearchComponent;
  let fixture: ComponentFixture<ScenariosSearchComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ScenariosSearchComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ScenariosSearchComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

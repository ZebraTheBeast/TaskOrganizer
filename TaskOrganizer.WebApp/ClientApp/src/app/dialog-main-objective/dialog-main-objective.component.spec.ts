import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { DialogMainObjective } from './dialog-main-objective.component';

describe('DialogMainObjectiveComponent', () => {
  let component: DialogMainObjective;
  let fixture: ComponentFixture<DialogMainObjective>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ DialogMainObjective ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(DialogMainObjective);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { DialogChildObjective } from './dialog-child-objective.component';

describe('DialogChildObjectiveComponent', () => {
  let component: DialogChildObjective;
  let fixture: ComponentFixture<DialogChildObjective>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ DialogChildObjective ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(DialogChildObjective);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

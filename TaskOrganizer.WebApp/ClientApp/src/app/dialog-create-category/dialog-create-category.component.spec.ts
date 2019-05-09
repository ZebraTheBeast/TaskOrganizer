import { async, ComponentFixture, TestBed } from '@angular/core/testing';
import { DialogCreateCategory } from './dialog-create-category.component';

describe('DialogCreateCategoryComponent', () => {
  let component: DialogCreateCategory;
  let fixture: ComponentFixture<DialogCreateCategory>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ DialogCreateCategory ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(DialogCreateCategory);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

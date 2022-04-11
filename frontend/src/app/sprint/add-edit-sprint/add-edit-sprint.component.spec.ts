import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AddEditSprintComponent } from './add-edit-sprint.component';

describe('AddEditSprintComponent', () => {
  let component: AddEditSprintComponent;
  let fixture: ComponentFixture<AddEditSprintComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AddEditSprintComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(AddEditSprintComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ShowSprintComponent } from './show-sprint.component';

describe('ShowSprintComponent', () => {
  let component: ShowSprintComponent;
  let fixture: ComponentFixture<ShowSprintComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ShowSprintComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ShowSprintComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

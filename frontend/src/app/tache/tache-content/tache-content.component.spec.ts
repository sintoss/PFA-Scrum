import { ComponentFixture, TestBed } from '@angular/core/testing';

import { TacheContentComponent } from './tache-content.component';

describe('TacheContentComponent', () => {
  let component: TacheContentComponent;
  let fixture: ComponentFixture<TacheContentComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ TacheContentComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(TacheContentComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

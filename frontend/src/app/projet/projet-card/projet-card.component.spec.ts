import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ProjetCardComponent } from './projet-card.component';

describe('ProjetCardComponent', () => {
  let component: ProjetCardComponent;
  let fixture: ComponentFixture<ProjetCardComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ProjetCardComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ProjetCardComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

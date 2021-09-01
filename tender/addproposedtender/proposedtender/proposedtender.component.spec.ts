import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ProposedtenderComponent } from './proposedtender.component';

describe('ProposedtenderComponent', () => {
  let component: ProposedtenderComponent;
  let fixture: ComponentFixture<ProposedtenderComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ProposedtenderComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ProposedtenderComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

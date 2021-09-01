import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CapturequotationComponent } from './capturequotation.component';

describe('CapturequotationComponent', () => {
  let component: CapturequotationComponent;
  let fixture: ComponentFixture<CapturequotationComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ CapturequotationComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(CapturequotationComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

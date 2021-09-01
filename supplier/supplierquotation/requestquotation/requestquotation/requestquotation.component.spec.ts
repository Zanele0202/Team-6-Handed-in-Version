import { ComponentFixture, TestBed } from '@angular/core/testing';

import { RequestquotationComponent } from './requestquotation.component';

describe('RequestquotationComponent', () => {
  let component: RequestquotationComponent;
  let fixture: ComponentFixture<RequestquotationComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ RequestquotationComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(RequestquotationComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

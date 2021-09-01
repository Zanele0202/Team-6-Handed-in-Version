import { ComponentFixture, TestBed } from '@angular/core/testing';

import { SupplierquotationComponent } from './supplierquotation.component';

describe('SupplierquotationComponent', () => {
  let component: SupplierquotationComponent;
  let fixture: ComponentFixture<SupplierquotationComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ SupplierquotationComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(SupplierquotationComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

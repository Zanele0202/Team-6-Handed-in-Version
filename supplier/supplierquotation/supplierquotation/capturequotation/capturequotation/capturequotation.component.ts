import { Component, OnInit } from '@angular/core';
import {SupplierService} from 'src/app/services/supplier.service';
import { Supplier } from 'src/app/interfaces/supplier';
import { AbstractControlOptions, FormBuilder, FormGroup, Validators, FormControl } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';



@Component({
  selector: 'app-capturequotation',
  templateUrl: './capturequotation.component.html',
  styleUrls: ['./capturequotation.component.sass']
})
export class CapturequotationComponent implements OnInit {

  form!: FormGroup;
   
  constructor(
    public supplierService: SupplierService,
    private router: Router
  ) { }
  
  ngOnInit(): void {
    this.form = new FormGroup({
      supplierName: new FormControl('', [Validators.required]),
      supplierEmail: new FormControl('', Validators.required),
      supplierTelephone: new FormControl('', [Validators.required]),
      supplierAddress: new FormControl('', Validators.required)
    });
  }

  get f(){
    return this.form.controls;
  }
    
  submit(){
    console.log(this.form.value);
    this.supplierService.create(this.form.value).subscribe(res => {
         console.log('Supplier added successfully!');
         this.router.navigateByUrl('supplier');
    });

  }

}

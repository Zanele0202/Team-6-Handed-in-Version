import { Component, OnInit } from '@angular/core';
import {SupplierService} from 'src/app/services/supplier.service';
import { Supplier } from 'src/app/interfaces/supplier';
import { AbstractControlOptions, FormBuilder, FormGroup, Validators, FormControl } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { MatDialog } from '@angular/material/dialog';

@Component({
  selector: 'app-add-edit-supplier',
  templateUrl: './add-edit-supplier.component.html',
  styleUrls: ['./add-edit-supplier.component.sass']
})
export class AddEditSupplierComponent implements OnInit {

  form!: FormGroup;
  retail!: string;
  rental!: string;
  dialogRef: any;
   
  constructor(
    public supplierService: SupplierService,
    private router: Router,
    public dialog: MatDialog
  ) { }

  openDialog(): void {
    const dialogRef = this.dialog.open(AddEditSupplierComponent, {
      width: '250px',
      data: {retail: this.retail, rental: this.rental}
    });

    dialogRef.afterClosed().subscribe(result => {
      console.log('The dialog was closed');
      this.retail = result;
    });
  }

  onNoClick(): void {
    this.dialogRef.close();
  }
  
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

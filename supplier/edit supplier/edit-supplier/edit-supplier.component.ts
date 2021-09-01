import { Supplier } from './../../../interfaces/supplier';
import { Component, OnInit } from '@angular/core';
import { SupplierService } from 'src/app/services/supplier.service';
import { ActivatedRoute, Router } from '@angular/router';
import { FormGroup, FormControl, Validators} from '@angular/forms';

@Component({
  selector: 'app-edit-supplier',
  templateUrl: './edit-supplier.component.html',
  styleUrls: ['./edit-supplier.component.sass']
})
export class EditSupplierComponent implements OnInit {

  id!: number;
  supplier!: Supplier;
  form!: FormGroup;
  dialogRef: any;


  constructor(
    private router: Router,
    public supplierService: SupplierService,
    private route: ActivatedRoute,
  ) { }

  ngOnInit(): void {
    this.id = this.route.snapshot.params['taskId'];
    this.supplierService.find(this.id).subscribe((data: Supplier)=>{
      this.supplier = data;
    });
  

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
  this.supplierService.update(this.id, this.form.value).subscribe(res => {
       console.log('Supplier updated successfully!');
       this.router.navigateByUrl('supplier');
  })
}

onNoClick(): void {
  this.dialogRef.close();
}

}

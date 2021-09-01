import { Component, OnInit } from '@angular/core';
import { Supplier } from '../interfaces/supplier';
import { SupplierService } from '../services/supplier.service';


@Component({
  templateUrl: './supplier.component.html',
  styleUrls: ['./supplier.component.sass']
})
export class SupplierComponent implements OnInit {

  supplier: Supplier[] = [];
  
  constructor(public supplierService: SupplierService) { }
  
  ngOnInit(): void {
    this. supplierService.getAll().subscribe((data: Supplier[])=>{
      this.supplier = data;
      console.log(this.supplier);
    })  
  }
  
  deleteSupplier(id: number){
    this. supplierService.delete(id).subscribe(res => {
         this.supplier = this.supplier.filter(item => item.id !== id);
         console.log('Supplier deleted successfully!');
    })
  }
}

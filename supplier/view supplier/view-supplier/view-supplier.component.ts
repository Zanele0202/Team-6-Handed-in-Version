import { Supplier } from './../../../interfaces/supplier';
import { Component, OnInit } from '@angular/core';
import { SupplierService } from 'src/app/services/supplier.service';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'app-view-supplier',
  templateUrl: './view-supplier.component.html',
  styleUrls: ['./view-supplier.component.sass']
})
export class ViewSupplierComponent implements OnInit {

  id!: number;
  suppliers!: Supplier ;
   
  constructor(
    public supplierService: SupplierService,
    private route: ActivatedRoute,
    private router: Router
   ) { }
  
  ngOnInit(): void {
    this.id = this.route.snapshot.params['supplierId'];
      
    this.supplierService.find(this.id).subscribe((data: Supplier)=>{
      this.suppliers = data;
    });
  }

}

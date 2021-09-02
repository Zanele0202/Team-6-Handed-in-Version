import { Component, OnInit, ViewChild } from '@angular/core';
import { Router } from '@angular/router';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { ApiService } from '../api.service';

@Component({
  selector: 'app-inventory',
  templateUrl: './inventory.component.html',
  styleUrls: ['./inventory.component.css']
})
export class InventoryComponent implements OnInit {
  @ViewChild('confirmDeletion') confirmDeletion : any;
  @ViewChild('success') success : any;
  inventory=[];
  keywords='';
  constructor
  (    
    private apiService:ApiService,
    private modalService: NgbModal,
    private router: Router,
    
  )    
  { }

  
  ngOnInit(): void {
    this.loadAllInventory()
  }
  loadAllInventory() { 
    this.apiService.getAllInventory().subscribe(inventory=>{
     this.inventory = inventory;
   console.log(inventory)
     });  
   } 
   
   confirmDelete(id){
    sessionStorage.setItem('deleteInventoryID',id.toString());
    this.modalService.open(this.confirmDeletion,{ centered: true});

  }

  deleteInventory(){
    this.apiService.deleteInventoryById(sessionStorage.getItem('deleteInventoryID')).subscribe(data=>{
      this.modalService.dismissAll();
      this.loadAllInventory();
      sessionStorage.removeItem('deleteInventoryID');
      this.modalService.open(this.success,{ centered: true});
     
});

  }

}

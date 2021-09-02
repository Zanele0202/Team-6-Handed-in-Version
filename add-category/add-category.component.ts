import { HttpClient } from '@angular/common/http';
import { Component, OnInit, ViewChild } from '@angular/core';
import { FormBuilder, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { ApiService } from '../api.service';


@Component({
  selector: 'app-add-category',
  templateUrl: './add-category.component.html',
  styleUrls: ['./add-category.component.css']
})
export class AddCategoryComponent implements OnInit {
  @ViewChild('confirm') confirm : any;
  @ViewChild('success') success : any;

  categoryForm: any;

  constructor
  (
    private modalService: NgbModal,
    private httpService: HttpClient,
    private apiService:ApiService ,
    private formBuilder: FormBuilder,
    private router: Router,
    ) 
    {
      this.categoryForm = this.formBuilder.group({
        Category_Name : ['', Validators.required],
        Category_Description : ['', Validators.required],
       
      });
    

     }

  ngOnInit(): void {
  }

  confirmCategory() {
    this.modalService.open(this.confirm,{ centered: true });
  } 

  creationSuccess() {
    this.modalService.open(this.success,{ centered: true });
  } 

  createCategory(){
    var newCategory =this.categoryForm.value;
    this.apiService.createCategory(newCategory).subscribe((data: any[])=>{
      this.router.navigate(["/category"]);
      this.modalService.dismissAll();
      this.creationSuccess();
    })  
  }

}

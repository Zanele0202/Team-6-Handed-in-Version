import { HttpClient } from '@angular/common/http';
import { Component, OnInit, ViewChild } from '@angular/core';
import { FormBuilder, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { ApiService } from '../api.service';

@Component({
  selector: 'app-category',
  templateUrl: './category.component.html',
  styleUrls: ['./category.component.css']
})
export class CategoryComponent implements OnInit {
  @ViewChild('confirmDeletion') confirmDeletion : any;
  @ViewChild('success') success : any;
  categories=[];
  keywords='';

  constructor
  (
    private apiService:ApiService,
    private modalService: NgbModal,
    private router: Router,
  )
  {
  }

  ngOnInit(): void {
    this.loadAllCategories();
  }

  loadAllCategories() {

  this.apiService.getAllCategories().subscribe(categories=>{
     console.log('this cat from serv', categories)
    this.categories = categories;

    });
    return this.categories;
  }

  confirmDelete(id){
    sessionStorage.setItem('deleteCategoryID',id.toString());
    this.modalService.open(this.confirmDeletion,{ centered: true});

  }

  deleteCategory(){
    this.apiService.deleteCategoryById(sessionStorage.getItem('deleteCategoryID')).subscribe(data=>{
      this.modalService.dismissAll();
      this.loadAllCategories();
      sessionStorage.removeItem('deleteCategoryID');
      this.modalService.open(this.success,{ centered: true});

});

  }

  updateCategory(id){
    sessionStorage.setItem('updateCategoryID',id.toString());
    this.router.navigate(["/update-category"]);

  }


  copylistOfData = [...this.categories];

  search(search){debugger;

     const targetValue: any[] = [];
    this.copylistOfData.forEach((value: any) => {
      let keys = Object.keys(value);
      for (let i = 0; i < keys.length; i++) {
        if (value[keys[i]] && value[keys[i]].toString().toLocaleLowerCase().includes(search)) {
          targetValue.push(value);
          console.log(targetValue)
          break;
        }
      }
    });
    this.categories = targetValue;
  }




}

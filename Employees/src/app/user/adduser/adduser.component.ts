import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';

@Component({
  selector: 'app-adduser',
  templateUrl: './adduser.component.html',
  styleUrls: ['./adduser.component.css']
})
export class AdduserComponent implements OnInit {

  addform: FormGroup;

  constructor(private formBuilder: FormBuilder, private router: Router) { }

  ngOnInit(): void {
  this.addform = this.formBuilder.group({
    firstname: ['', Validators.required],
    lastname: ['', Validators.required],
    idno: ['', Validators.required],
    homeaddress: ['', Validators.required],
    email: ['', Validators.required],
    telno: [''],
    cellno: ['', Validators.required],
    emptype: ['', Validators.required],
    });
  }

  submit(form){
    console.log('here')
    console.log(form)
    var user = localStorage.getItem("usersList"); //list<users> users = db.users.tolist()
    var Data = JSON.parse(user);
    if(Data==null)
    {
     var list = []
      localStorage.setItem("usersList", JSON.stringify(list));
      var user = localStorage.getItem("usersList");
      Data = JSON.parse(user);
    }
    Data.push(form)
    localStorage.setItem("usersList", JSON.stringify(Data));
    this.router.navigate(["user"])
  }

  cancel(){
    this.router.navigate(["user"])
  }
}

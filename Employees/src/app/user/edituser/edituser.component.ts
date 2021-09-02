import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';

@Component({
  selector: 'app-edituser',
  templateUrl: './edituser.component.html',
  styleUrls: ['./edituser.component.css']
})
export class EdituserComponent implements OnInit {

  editform: FormGroup;

  constructor(private formBuilder: FormBuilder, private router: Router) { }

  ngOnInit(): void {
    var id = localStorage["ID"];
    var user = localStorage.getItem("usersList");
    var Data = JSON.parse(user);

    this.editform = this.formBuilder.group({
      firstname: [Data[id].firstname, Validators.required],
      lastname: [Data[id].lastname, Validators.required],
      idno: [Data[id].idno, Validators.required],
      homeaddress: [Data[id].homeaddress, Validators.required],
      email: [Data[id].email, Validators.required],
      role: [Data[id].role, Validators.required],
      telno: [Data[id].telno, Validators.required],
      cellno: [Data[id].cellno, Validators.required],
      emptype: [Data[id].emptype, Validators.required],  
     });
    }

    onFormSubmit(form)
    {
    var id = localStorage["ID"];
    var user = localStorage.getItem("usersList");
    var Data = JSON.parse(user);

    Data[id] = form;
    localStorage.setItem("usersList", JSON.stringify(Data));
    
    this.router.navigate(["user"])
    }

    cancel(){
      this.router.navigate(["user"])
    }
}

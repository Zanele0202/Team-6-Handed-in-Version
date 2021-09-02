import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-dialog',
  templateUrl: './dialog.component.html',
  styleUrls: ['./dialog.component.css']
})
export class DialogComponent implements OnInit {

  constructor() { }

  ngOnInit(): void {
  }

  delete(){
  // var users = localStorage.getItem("usersList");
  //  var Data = JSON.parse(users);
  //  Data.splice(localStorage["userToDelete"],1);
  //  localStorage.setItem("usersList", JSON.stringify(Data));

  }

}

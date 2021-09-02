import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import {MatTableDataSource} from '@angular/material/table';
import { MatDialog } from '@angular/material/dialog';
import {DialogComponent} from '../user/dialog/dialog.component';

export interface UserData {
  firstname: String;
  lastname: String;
  title: String;
  email: String;
  cellno: String;
  emptype: String;
}

const DATA: UserData[] = [{
  firstname: "",
  lastname: "",
  title: "",
  email: "",
  cellno: "",
  emptype: "",

}]


@Component({
  selector: 'app-user', 
  templateUrl: './user.component.html',
  styleUrls: ['./user.component.css']
})

export class UserComponent implements OnInit {

  displayedColumns: string[] = ["firstname","email", "cellno", "emptype","delete" ];

  dataSource = new MatTableDataSource(DATA);

  constructor(private router:Router) { }

  ngOnInit(): void {
    var users = localStorage.getItem("usersList");
    var data = JSON.parse(users);
    this.dataSource = new MatTableDataSource(data);
  }

  add(){
    this.router.navigate(['adduser'])
  }

  edit(i){
    localStorage["ID"] = i;
    this.router.navigate(['edituser'])
  }

  removeAt(i) {
    localStorage["userToDelete"] = i;

    var users = localStorage.getItem("usersList");
    var Data = JSON.parse(users);
    Data.splice(i,1);

    this.dataSource = new MatTableDataSource(Data);
    localStorage.setItem("usersList", JSON.stringify(Data));

    // const dialogRef = this.dialog.open(DialogComponent, {
    //   height: '600px', width: '1200px',
    // });

    // dialogRef.afterClosed().subscribe(result => {
    //   var users = localStorage.getItem("usersList");
    //   var Data = JSON.parse(users);
    //   this.dataSource = new MatTableDataSource(Data);
    // });
  }
}

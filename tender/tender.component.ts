import { Component, OnInit } from '@angular/core';
import {MatDialog, MatDialogRef, MAT_DIALOG_DATA} from '@angular/material/dialog';
import { ReactiveFormsModule } from '@angular/forms';

export interface DialogData {
  accept: string;
  decline: string;
}

@Component({
  templateUrl: './tender.component.html',
  styleUrls: ['./tender.component.sass']
})
export class TenderComponent implements OnInit {

  accept!: string;
  decline!: string;
  dialogRef: any;

  constructor(public dialog: MatDialog) {}

  openDialog(): void {
    const dialogRef = this.dialog.open(TenderComponent, {
      width: '250px',
      data: {decline: this.decline, accept: this.accept}
    });

    dialogRef.afterClosed().subscribe(result => {
      console.log('The dialog was closed');
      this.accept = result;
    });
  }

  onNoClick(): void {
    this.dialogRef.close();
  }

  ngOnInit(): void {
  }

  title = 'Angular Search Using ng2-search-filter';
  searchText: any;
  tender = [
    {description: 'Building toilets', company: 'Sunnyside Pre-Priimary school', date: '22 March 2021', status: 'accepted' },
    {description: 'Painitng and fixing roof' , company: 'Nacro Grand designs', date: '2 June 2021', status: 'submitted'},
    {description: 'Lift installations' , company: 'Municipal offices', date: '13 May 2021', status: 'submitted'},
    {description: 'Residential building' , company: 'Cradle residential designs',date: '22 August 2021', status: 'accepted' }
  ];

}

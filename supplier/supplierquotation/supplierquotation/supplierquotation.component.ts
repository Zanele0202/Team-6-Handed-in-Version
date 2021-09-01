import { Component, OnInit } from '@angular/core';
import {MatDialog, MatDialogRef, MAT_DIALOG_DATA} from '@angular/material/dialog';

export interface DialogData {
  accept: string;
  decline: string;
}

@Component({
  selector: 'app-supplierquotation',
  templateUrl: './supplierquotation.component.html',
  styleUrls: ['./supplierquotation.component.sass']
})
export class SupplierquotationComponent implements OnInit {

  accept!: string;
  decline!: string;
  dialogRef: any;

  constructor(public dialog: MatDialog) {}

  openDialog(): void {
    const dialogRef = this.dialog.open(SupplierquotationComponent, {
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

}


import { Component, OnInit } from '@angular/core';
import { FormBuilder, Validators } from '@angular/forms';  
import { Observable } from 'rxjs';
import { EquipmentService } from '../equipment.service';
import { Equipment } from '../equipment';


@Component({
  selector: 'app-equipment',
  templateUrl: './equipment.component.html',
  styleUrls: ['./equipment.component.css']
})
export class EquipmentComponent implements OnInit {

  dataSaved = false;  
  EquipmentForm: any;  
  allEquipment!: Observable<Equipment[]>;  
  equipmentIDupdate = "";  
  message = ""  
  
  constructor(private formbulider: FormBuilder, private equipmentService:EquipmentService) { }  
  
  ngOnInit() {  
    this.EquipmentForm = this.formbulider.group({
      EquipmentID: ['', [Validators.required]],
      EquipmentName: ['', [Validators.required]],  
      EquipmentDescription: ['', [Validators.required]],  
      Quantity: ['', [Validators.required]],    
    });  
    this.loadAllEquipment();  
  }  
  loadAllEquipment() {  
    this.allEquipment = this.equipmentService.GetEquipment();  
  }  
  onFormSubmit() {  
    this.dataSaved = false;  
    const EQUIPMENT = this.EquipmentForm.value;  
    this.CreateEquipment(EQUIPMENT);  
    this.EquipmentForm.reset();  
  }  
  loadEquipmentToUpdate(EquipmentID: string) {  
    this.equipmentService.GetEquipmentByID(EquipmentID).subscribe(equipment=> {  
      this.message = "";  
      this.dataSaved = false;  
      this.equipmentIDupdate = equipment.EquipmentID;  
      this.EquipmentForm.controls['EquipmentID'].setValue(equipment.EquipmentID);  
      this.EquipmentForm.controls['EquipmentName'].setValue(equipment.EquipmentName);  
      this.EquipmentForm.controls['EquipmentDescription'].setValue(equipment.EquipmentDescription);  
      this.EquipmentForm.controls['Quantity'].setValue(equipment.Quantity);  
    });  
  
  }  
  CreateEquipment(equipment: Equipment) {  
    if (this.equipmentIDupdate == null) {  
      this.equipmentService.createEquipment(equipment).subscribe(  
        () => {  
          this.dataSaved = true;  
          this.message = 'Record saved Successfully';  
          this.loadAllEquipment();  
          this.equipmentIDupdate = "";  
          this.EquipmentForm.reset();  
        }  
      );  
    } else {  
      equipment.EquipmentID = this.equipmentIDupdate;  
      this.equipmentIDupdate.updateEquipment(equipment).subscribe(() => {  
        this.dataSaved = true;  
        this.message = 'Record Updated Successfully';  
        this.loadAllEquipment();  
        this.equipmentIDupdate = "";  
        this.EquipmentForm.reset();  
      });  
    }  
  }   
  deleteEquipment(equipmentID: string) {  
    if (confirm("Are you sure you want to delete this ?")) {   
    this.equipmentService.deleteEquipmentById(equipmentID).subscribe(() => {  
      this.dataSaved = true;  
      this.message = 'Record Deleted Succefully';  
      this.loadAllEquipment();  
      this.equipmentIDupdate = "";  
      this.EquipmentForm.reset();  
  
    });  
  }  
}  
  resetForm() {  
    this.EquipmentForm.reset();  
    this.message = "";  
    this.dataSaved = false;  
  }  

}

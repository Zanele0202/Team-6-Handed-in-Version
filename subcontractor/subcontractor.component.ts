import { Component, OnInit } from '@angular/core';
import { FormBuilder, Validators } from '@angular/forms';  
import { Observable } from 'rxjs';
import { SubcontractorService } from '../subcontractor.service';
import { Subcontractor } from '../subcontractor';

@Component({
  selector: 'app-subcontractor',
  templateUrl: './subcontractor.component.html',
  styleUrls: ['./subcontractor.component.css']
})
export class SubcontractorComponent implements OnInit {

  dataSaved = false;  
  SubcontractorForm: any;  
  allSubcontractors!: Observable<Subcontractor[]>;  
  subcontractorIDupdate = "";  
  message = ""  
  
  constructor(private formbulider: FormBuilder, private subcontractorService:SubcontractorService) { }  
  
  ngOnInit() {  
    this.SubcontractorForm = this.formbulider.group({
      SubcontractorID: ['', [Validators.required]],
      SubName: ['', [Validators.required]],  
      SubAddress: ['', [Validators.required]],  
      SubJobDescription: ['', [Validators.required]],  
      TelephoneNumber: ['', [Validators.required]], 
      EmailAddress: ['', [Validators.required]],   
    });  
    this.loadAllSubcontractors();  
  }  
  loadAllSubcontractors() {  
    this.allSubcontractors = this.subcontractorService.getSubcontractor();  
  }  
  onFormSubmit() {  
    this.dataSaved = false;  
    const PHASE = this.SubcontractorForm.value;  
    this.CreateSubcontractor(PHASE);  
    this.SubcontractorForm.reset();   
  }  
  loadSubcontractorToUpdate(PhaseID: string) {  
    this.subcontractorService.getSubcontractorById(SubcontractorID).subscribe(subcontractor=> {  
      this.message = "";  
      this.dataSaved = false;  
      this.subcontractorIDupdate = subcontractor.SubcontractorID;  
      this.SubcontractorForm.controls['SubcontractorID'].setValue(subcontractor.SubcontractorID);  
     this.SubcontractorForm.controls['SubName'].setValue(subcontractor.SubName);  
      this.SubcontractorForm.controls['SubAddress'].setValue(subcontractor.SubAddress);  
      this.SubcontractorForm.controls['SubJobDescription'].setValue(subcontractor.SubJobDescription);  
      this.SubcontractorForm.controls['TelephoneNumber'].setValue(subcontractor.TelephoneNumber);  
      this.SubcontractorForm.controls['EmailAddress'].setValue(subcontractor.EmailAddress); 
    });  
  
  }  
  CreatePhase(subcontractor: Subcontractor) {  
    if (this.subcontractorIDupdate == null) {  
      this.subcontractorService.createSubcontractor(subcontractor).subscribe(  
        () => {  
          this.dataSaved = true;  
          this.message = 'Record saved Successfully';  
          this.loadAllSubcontractors();  
          this.subcontractorIDupdate = "";  
          this.SubcontractorForm.reset();  
        }  
      );  
    } else {  
      subcontractor.SubcontractorID = this.subcontractorIDupdate;  
      this.subcontractorService.updateSubcontractor(subcontractor).subscribe(() => {  
        this.dataSaved = true;  
        this.message = 'Record Updated Successfully';  
        this.loadAllSubcontractors();  
        this.subcontractorIDupdate = "";  
        this.SubcontractorForm.reset();  
      });  
    }  
  }   
  deletePhase(subcontractorID: string) {  
    if (confirm("Are you sure you want to delete this ?")) {   
    this.subcontractorService.deleteSubcontractorById(subcontractorID).subscribe(() => {  
      this.dataSaved = true;  
      this.message = 'Record Deleted Succefully';  
      this.loadAllSubcontractors();  
      this.subcontractorIDupdate = "";  
      this.SubcontractorForm.reset();  
  
    });  
  }  
}  
  resetForm() {  
    this.SubcontractorForm.reset();  
    this.message = "";  
    this.dataSaved = false;  
  }  

}

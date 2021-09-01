import { Component, OnInit } from '@angular/core';
import { FormBuilder, Validators } from '@angular/forms';  
import { Observable } from 'rxjs';
import { PhaseService } from '../phase.service';
import { Phase } from '../phase';

@Component({
  selector: 'app-phase',
  templateUrl: './phase.component.html',
  styleUrls: ['./phase.component.css']
})
export class PhaseComponent implements OnInit {

  dataSaved = false;  
  PhaseForm: any;  
  allPhases!: Observable<Phase[]>;  
  phaseIDupdate = "";  
  message = ""  
  
  constructor(private formbulider: FormBuilder, private phaseService:PhaseService) { }  
  
  ngOnInit() {  
    this.PhaseForm = this.formbulider.group({
      PhaseID: ['', [Validators.required]],
      PhaseName: ['', [Validators.required]],  
      PhaseDescription: ['', [Validators.required]],  
      StartDate: ['', [Validators.required]],  
      EndDate: ['', [Validators.required]],    
    });  
    this.loadAllPhases();  
  }  
  loadAllPhases() {  
    this.allPhases = this.phaseService.getPhase();  
  }  
  onFormSubmit() {  
    this.dataSaved = false;  
    const PHASE = this.PhaseForm.value;  
    this.CreatePhase(PHASE);  
    this.PhaseForm.reset();  
  }  
  loadPhaseToUpdate(PhaseID: string) {  
    this.phaseService.getPhaseById(PhaseID).subscribe(phase=> {  
      this.message = "";  
      this.dataSaved = false;  
      this.phaseIDupdate = phase.PhaseID;  
      this.PhaseForm.controls['PhaseID'].setValue(phase.PhaseID);  
     this.PhaseForm.controls['PhaseName'].setValue(phase.PhaseName);  
      this.PhaseForm.controls['PhaseDescription'].setValue(phase.PhaseDescription);  
      this.PhaseForm.controls['StartDate'].setValue(phase.StartDate);  
      this.PhaseForm.controls['EndDate'].setValue(phase.EndDate);  
    });  
  
  }  
  CreatePhase(phase: Phase) {  
    if (this.phaseIDupdate == null) {  
      this.phaseService.createPhase(phase).subscribe(  
        () => {  
          this.dataSaved = true;  
          this.message = 'Record saved Successfully';  
          this.loadAllPhases();  
          this.phaseIDupdate = "";  
          this.PhaseForm.reset();  
        }  
      );  
    } else {  
      phase.PhaseID = this.phaseIDupdate;  
      this.phaseService.updatePhase(phase).subscribe(() => {  
        this.dataSaved = true;  
        this.message = 'Record Updated Successfully';  
        this.loadAllPhases();  
        this.phaseIDupdate = "";  
        this.PhaseForm.reset();  
      });  
    }  
  }   
  deletePhase(phaseID: string) {  
    if (confirm("Are you sure you want to delete this ?")) {   
    this.phaseService.deletePhaseById(phaseID).subscribe(() => {  
      this.dataSaved = true;  
      this.message = 'Record Deleted Succefully';  
      this.loadAllPhases();  
      this.phaseIDupdate = "";  
      this.PhaseForm.reset();  
  
    });  
  }  
}  
  resetForm() {  
    this.PhaseForm.reset();  
    this.message = "";  
    this.dataSaved = false;  
  }  

}

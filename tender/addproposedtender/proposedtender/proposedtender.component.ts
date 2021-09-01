import { Component, OnInit } from '@angular/core';
import { Tender } from 'src/app/interfaces/tender';
import { AbstractControlOptions, FormBuilder, FormGroup, Validators, FormControl } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { TenderService } from 'src/app/services/tender.service';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';


@Component({
  selector: 'app-proposedtender',
  templateUrl: './proposedtender.component.html',
  styleUrls: ['./proposedtender.component.sass']
})
export class ProposedtenderComponent implements OnInit {

  form!: FormGroup;
   
  constructor(
    public tenderService: TenderService,
    private router: Router
  ) { }
  
  ngOnInit(): void {
    this.form = new FormGroup({
      clientName: new FormControl('', [Validators.required]),
      tenderDescription: new FormControl('', [Validators.required]),
      dateSubmitted: new FormControl('', Validators.required),
      tenderStatus: new FormControl('', Validators.required)
    });
  }

  get f(){
    return this.form.controls;
  }
    
  submit(){
    console.log(this.form.value);
    this.tenderService.create(this.form.value).subscribe(res => {
         console.log('Proposed tender added successfully!');
         this.router.navigateByUrl('tender');
    });

  }

}

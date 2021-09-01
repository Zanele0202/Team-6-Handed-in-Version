import { Component, OnInit } from '@angular/core';
import { Task } from 'src/app/interfaces/taskIndex';
import { AbstractControlOptions, FormBuilder, FormGroup, Validators, FormControl } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { TaskService } from 'src/app/services/task.service';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';


@Component({
  selector: 'app-add-edit-task',
  templateUrl: './add-edit-task.component.html',
  styleUrls: ['./add-edit-task.component.sass']
})
export class AddEditTaskComponent implements OnInit {

  form!: FormGroup;
   
  constructor(
    public taskService: TaskService,
    private router: Router
  ) { }
  
  ngOnInit(): void {
    this.form = new FormGroup({
      taskname: new FormControl('', [Validators.required]),
      phasename: new FormControl('', Validators.required),
      taskdescription: new FormControl('', [Validators.required]),
      startDate: new FormControl('', Validators.required),
       endDate: new FormControl('', [Validators.required]),
      taskequipment: new FormControl('', Validators.required)
    });
  }
   
  get f(){
    return this.form.controls;
  }
    
  submit(){
    console.log(this.form.value);
    this.taskService.createTask(this.form.value).subscribe(res => {
         console.log('Task added successfully!');
         this.router.navigateByUrl('task');
    });

  }

}
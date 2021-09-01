import { Component, OnInit } from '@angular/core';
import { TaskService } from 'src/app/services/task.service';
import { ActivatedRoute, Router } from '@angular/router';
import { Task } from 'src/app/interfaces/taskIndex';
import { FormGroup, FormControl, Validators} from '@angular/forms';

@Component({
  selector: 'app-edit-task',
  templateUrl: './edit-task.component.html',
  styleUrls: ['./edit-task.component.sass']
})
export class EditTaskComponent implements OnInit {

  id!: number;
  task!: Task;
  form!: FormGroup;


  constructor(
    private router: Router,
    public taskService: TaskService,
    private route: ActivatedRoute,
  ) { }

  ngOnInit(): void {
    this.id = this.route.snapshot.params['taskId'];
    this.taskService.findTask(this.id).subscribe((data: Task)=>{
      this.task = data;
    });

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
    this.taskService.updateTask(this.id, this.form.value).subscribe(res => {
         console.log('Task updated successfully!');
         this.router.navigateByUrl('task');
    })
  }

}

import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Task } from 'src/app/interfaces/taskIndex';
import { FormGroup, FormControl, Validators} from '@angular/forms';
import { TaskService } from 'src/app/services/task.service';

@Component({
  selector: 'app-viewtask',
  templateUrl: '././viewtask.component.html',
  styleUrls: ['./viewtask.component.sass']
})
export class ViewtaskComponent implements OnInit {

  id!: number;
  task!: Task ;
   
  constructor(
    public taskService: TaskService,
    private route: ActivatedRoute,
    private router: Router
   ) { }
  
  ngOnInit(): void {
    this.id = this.route.snapshot.params['taskId'];
      
    this.taskService.findTask(this.id).subscribe((data: Task)=>{
      this.task = data;
    });
  }
}

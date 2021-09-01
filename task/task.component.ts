import { Component, OnInit } from '@angular/core';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import {FormsModule } from '@angular/forms';
import { TaskService } from '../services/task.service';
import { Task } from 'src/app/interfaces/taskIndex';
import { ReactiveFormsModule } from '@angular/forms';
import { MatIconModule } from '@angular/material/icon';
import { id } from '@swimlane/ngx-charts';

@Component({
  templateUrl: './task.component.html',
  styleUrls: ['./task.component.sass']
})
export class TaskComponent implements OnInit {

  
  task: Task[] = [];
  
  constructor(public taskService: TaskService) { }
  
  ngOnInit(): void {
    this.taskService.getAll().subscribe((data: Task[])=>{
      this.task = data;
      console.log(this.task);
    })  
  }
  
  deleteTask(id:number){
    this.taskService.deleteTask(id).subscribe(res => {
         this.task = this.task.filter(item => item.taskId !== id);
         console.log('Task deleted successfully!');
    })
  }

}

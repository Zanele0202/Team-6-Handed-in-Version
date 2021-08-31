import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Task } from 'src/app/interfaces/taskIndex';

@Injectable({
  providedIn: 'root'
})
export class TaskService {



  constructor( private httpClient: HttpClient) { }


  


}



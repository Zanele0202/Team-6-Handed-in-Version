import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { throwError } from 'rxjs/internal/observable/throwError';
import { Task } from 'src/app/interfaces/taskIndex';

@Injectable({
  providedIn: 'root'
})
export class TaskService {

 readonly baseUrl = "https://localhost:44369/api/Tasks";
   
  httpOptions = {
    headers: new HttpHeaders({
      'Content-Type': 'application/json'
    })
  }

  constructor(private httpClient: HttpClient) { }
   
  getAll(): Observable<Task[]> {
    return this.httpClient.get<Task[]>(this.baseUrl + '/GetTasks/')
   
  }

  createTask(task: any): Observable<Task> {
    return this.httpClient.post<Task>(this.baseUrl + '/task/', JSON.stringify(task), this.httpOptions)
    
  }  
  
  findTask(id: number): Observable<Task> {
    return this.httpClient.get<Task>(this.baseUrl + '/task/' + id)
   
  }

  updateTask(id: number, task: any): Observable<Task> {
    return this.httpClient.put<Task>(this.baseUrl + '/task/' + id, JSON.stringify(task), this.httpOptions)
   
  }
   
  deleteTask(id: number){
    return this.httpClient.delete<Task>(this.baseUrl + '/DeleteTask/' + id, this.httpOptions)
    
  }

  errorHandler(error: { error: { message: string; }; status: any; message: any; }) {
    let errorMessage = '';
    if(error.error instanceof ErrorEvent) {
      errorMessage = error.error.message;
    } else {
      errorMessage = `Error Code: ${error.status}\nMessage: ${error.message}`;
    }
    return throwError(errorMessage);
 }

}



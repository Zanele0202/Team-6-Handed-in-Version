import { Injectable } from '@angular/core';  
import { HttpClient } from '@angular/common/http';  
import { HttpHeaders } from '@angular/common/http';  
import { Observable } from 'rxjs';
import { Phase } from './phase';

@Injectable({
  providedIn: 'root'
})
export class PhaseService {
  url = 'https://localhost:44393/Api/Phase';  
  constructor(private http: HttpClient) { }  
  getPhase(): Observable<Phase[]> {  
    return this.http.get<Phase[]>(this.url + '/AllPhases');
  }
  getPhaseById(PhaseID: string): Observable<Phase> {  
    return this.http.get<Phase>(this.url + '/GetPhasesId/' + PhaseID);  
  }  
  createPhase(phase: Phase): Observable<Phase> {  
    const httpOptions = { headers: new HttpHeaders({ 'Content-Type': 'application/json'}) };  
    return this.http.post<Phase>(this.url + '/InsertPhases/',  
    phase, httpOptions);  
  }  
  updatePhase(phase: Phase): Observable<Phase> {  
    const httpOptions = { headers: new HttpHeaders({ 'Content-Type': 'application/json'}) };  
    return this.http.put<Phase>(this.url + '/UpdatePhases/',  
    phase, httpOptions);  
  }  
  deletePhaseById(PhaseID: string): Observable<number> {  
    const httpOptions = { headers: new HttpHeaders({ 'Content-Type': 'application/json'}) };  
    return this.http.delete<number>(this.url + '/DeletePhases?id=' + PhaseID,  
 httpOptions);  
  }  

}

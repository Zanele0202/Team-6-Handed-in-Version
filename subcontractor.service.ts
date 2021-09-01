import { Injectable } from '@angular/core';  
import { HttpClient } from '@angular/common/http';  
import { HttpHeaders } from '@angular/common/http';  
import { Observable } from 'rxjs';
import { Subcontractor } from './subcontractor';

@Injectable({
  providedIn: 'root'
})
export class SubcontractorService {

  url = 'https://localhost:44393/Api/Subcontractor';  
  constructor(private http: HttpClient) { }  
  getSubcontractor(): Observable<Subcontractor[]> {  
    return this.http.get<Subcontractor[]>(this.url + '/AllSubcontractors');
  }
  getSubcontractorById(SubcontractorID: string): Observable<Subcontractor> {  
    return this.http.get<Subcontractor>(this.url + '/GetSubcontractorID/' + SubcontractorID);  
  }  
  createSubcontractor(subcontractor: Subcontractor): Observable<Subcontractor> {  
    const httpOptions = { headers: new HttpHeaders({ 'Content-Type': 'application/json'}) };  
    return this.http.post<Subcontractor>(this.url + '/InsertSubcontractor/',  
    subcontractor, httpOptions);  
  }  
  updateSubcontractor(subcontractor: Subcontractor): Observable<Subcontractor> {  
    const httpOptions = { headers: new HttpHeaders({ 'Content-Type': 'application/json'}) };  
    return this.http.put<Subcontractor>(this.url + '/UpdateSubcontractor/',  
    subcontractor, httpOptions);  
  }  
  deleteSubcontractorById(SubcontractorID: string): Observable<number> {  
    const httpOptions = { headers: new HttpHeaders({ 'Content-Type': 'application/json'}) };  
    return this.http.delete<number>(this.url + '/DeleteSubcontractor?id=' + SubcontractorID,  
 httpOptions);  
  }  
}

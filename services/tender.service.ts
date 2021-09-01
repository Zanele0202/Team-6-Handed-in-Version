import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { throwError } from 'rxjs/internal/observable/throwError';
import { Tender } from 'src/app/interfaces/tender';

@Injectable({
  providedIn: 'root'
})
export class TenderService {

  readonly baseUrl = "https://localhost:44369/api/Tenders";
   
  httpOptions = {
    headers: new HttpHeaders({
      'Content-Type': 'application/json'
    })
  }

  constructor(private httpClient: HttpClient) { }
   
  getAll(): Observable<Tender[]> {
    return this.httpClient.get<Tender[]>(this.baseUrl + '/GetTenders/')
   
  }

  create(tender: any): Observable<Tender> {
    return this.httpClient.post<Tender>(this.baseUrl + '/tender/', JSON.stringify(tender), this.httpOptions)
    
  }  
  
  find(id: number): Observable<Tender> {
    return this.httpClient.get<Tender>(this.baseUrl + '/tender/' + id)
   
  }

  delete(id: number){
    return this.httpClient.delete<Tender>(this.baseUrl + '/DeleteTender/' + id, this.httpOptions)
    
  }


  
}

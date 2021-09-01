import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { throwError } from 'rxjs/internal/observable/throwError';
import { Supplier } from './../interfaces/supplier';


@Injectable({
  providedIn: 'root'
})
export class SupplierService {

  readonly baseUrl = "https://localhost:44369/api/Suppliers";
   
  httpOptions = {
    headers: new HttpHeaders({
      'Content-Type': 'application/json'
    })
  }

  constructor(private httpClient: HttpClient) { }
   
  getAll(): Observable<Supplier[]> {
    return this.httpClient.get<Supplier[]>(this.baseUrl + '/GetSuppliers/')
   
  }

  create(supplier: any): Observable<Supplier> {
    return this.httpClient.post<Supplier>(this.baseUrl + '/supplier/', JSON.stringify(supplier), this.httpOptions)
    
  }  

  find(id: number): Observable<Supplier> {
    return this.httpClient.get<Supplier>(this.baseUrl + '/supplier/' + id)
   
  }

  update(id: number, supplier: any): Observable<Supplier> {
    return this.httpClient.put<Supplier>(this.baseUrl + '/supplier/' + id, JSON.stringify(supplier), this.httpOptions)
   
  }
   
  delete(id: number){
    return this.httpClient.delete<Supplier>(this.baseUrl + '/DeleteSupplier/' + id, this.httpOptions)
    
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

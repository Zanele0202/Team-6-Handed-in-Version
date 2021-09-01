import { Injectable } from '@angular/core';  
import { HttpClient } from '@angular/common/http';  
import { HttpHeaders } from '@angular/common/http';  
import { Observable } from 'rxjs';
import { Equipment } from './equipment';

@Injectable({
  providedIn: 'root'
})
export class EquipmentService {
  url = 'https://localhost:44393/Api/Equipment';  
  constructor(private http: HttpClient) { }  
  GetEquipment(): Observable<Equipment[]> {  
    return this.http.get<Equipment[]>(this.url + '/AllEquipment');
  }
  GetEquipmentByID(EquipmentID: string): Observable<Equipment> {  
    return this.http.get<Equipment>(this.url + '/GetEquipmentID/' + EquipmentID);  
  }  
  createEquipment(equipment: Equipment): Observable<Equipment> {  
    const httpOptions = { headers: new HttpHeaders({ 'Content-Type': 'application/json'}) };  
    return this.http.post<Equipment>(this.url + '/InsertEquipment/',  
    equipment, httpOptions);  
  }  
  updateEquipment(equipment: Equipment): Observable<Equipment> {  
    const httpOptions = { headers: new HttpHeaders({ 'Content-Type': 'application/json'}) };  
    return this.http.put<Equipment>(this.url + '/UpdateEquipment/',  
    equipment, httpOptions);  
  }  
  deleteEquipmentById(EquipmentID: string): Observable<number> {  
    const httpOptions = { headers: new HttpHeaders({ 'Content-Type': 'application/json'}) };  
    return this.http.delete<number>(this.url + '/DeleteEquipment?id=' + EquipmentID,  
 httpOptions);  
  }  

}


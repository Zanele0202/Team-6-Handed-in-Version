import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';


const httpOptions = { headers: new HttpHeaders({ 'Content-Type': 'application/json'}) };  

@Injectable({
  providedIn: 'root'
})
export class ApiService {
  apiUrl='http://localhost:62525/api/BrainyBunch/'
  constructor(private http: HttpClient) { }

  //Category||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||
  getAllCategories(): Observable<any[]> {  
    return this.http.get<any[]>(this.apiUrl + 'getCategories');  
  }  
  
  
  getCategoryDetailsById(categoryID: string): Observable<any> {  
  return this.http.get<any>(this.apiUrl + 'getCategoryDetailsById/' + categoryID);  
  }  
  
  
  
  
  createCategory(category: any): Observable<any> {  
  return this.http.post<any>(this.apiUrl + 'insertCategoryDetails/',category, httpOptions);  
  }  
  
  
  updateCategory(category: any): Observable<any> {  
  return this.http.put<any>(this.apiUrl + 'updateCategoryDetails/',category, httpOptions);  
  }  
  
  
  
  deleteCategoryById(categoryID: string): Observable<number> {  
  return this.http.delete<number>(this.apiUrl + 'deleteCategoryDetails?id=' +categoryID,httpOptions);  
  }  
  
  //Inventory||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||
  getAllInventory(): Observable<any[]> 
  {  
    return this.http.get<any[]>(this.apiUrl + 'getInventory');  
  }  
  
  createInventory(inventory: any): Observable<any> 
  {  
    return this.http.post<any>(this.apiUrl + 'insertInventoryDetails/',inventory, httpOptions);  
  }  
    
    
  deleteInventoryById(inventoryID: string): Observable<number> {  
  return this.http.delete<number>(this.apiUrl + 'deleteInventoryDetails?id=' +inventoryID,httpOptions);  
  }  

  //Orders||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||
  getAllOrders(): Observable<any[]> 
  {  
    return this.http.get<any[]>(this.apiUrl + 'getOrders');  
  }  
  
  createOrder(inventory: any): Observable<any> 
  {  
    return this.http.post<any>(this.apiUrl + 'insertOrderDetails/',inventory, httpOptions);  
  }  

}



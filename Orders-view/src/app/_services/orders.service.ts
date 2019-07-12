import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders, HttpParams } from '@angular/common/http';
import { Observable } from 'rxjs/Rx';
import { Items } from '../Model/Items';
const httpOptions = {
  header: new HttpHeaders({
    'Authorization': 'Bearer' + localStorage.getItem('token')
  })
};
@Injectable({
  providedIn: 'root'
})
export class OrdersService {
  baseUrl = 'http://localhost:5000/api/Orders/';


  constructor(private http: HttpClient) { }

  getOrders(userid): Observable<any> {

    return this.http.get<any>(this.baseUrl + 'Orders/' + userid);
  }

  insertOrders(itemsmodel: Items[]):Observable<Items> {
    console.log(itemsmodel)

    return this.http.post<Items>(this.baseUrl + 'InsertOrder',  itemsmodel
    );
  }
  deleteOrder(id) {
    return this.http.delete(this.baseUrl + 'Delete/', id);

  }
  getitems() {
    return this.http.get(this.baseUrl + 'item');
  }

}

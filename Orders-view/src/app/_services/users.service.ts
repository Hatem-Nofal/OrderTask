import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class UsersService {
  baseUrl = 'http://localhost:5000/api/User/';

  constructor(private http: HttpClient) { }
  getUsers() {
    return this.http.get(this.baseUrl + 'user');

  }
  addUser(model: any) {
    return this.http.post(this.baseUrl + 'register', model);
  }
  DeleteUser(id: number) {
    return this.http.post(this.baseUrl + 'Delete',id);
  }
}



import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

interface User {
  PersonID: number;
  FirstName: string;
  LastName: string;
  Email: string;
  AttachedCustomerID: number;
  UserGroupID: number;
}

@Injectable({
  providedIn: 'root',
})
export class UserService {
  constructor(private http: HttpClient) {}
  readonly baseURL = 'https://localhost:44364/api/user';

  getAllUsers() {
    return this.http.get(`${this.baseURL}`);
  }

  getUserByID(ID: number) {
    return this.http.get(`${this.baseURL}/${ID}`);
  }

  postUser(User: User) {
    return this.http.post(`${this.baseURL}`, User);
  }

  putUser(User: User) {
    return this.http.put(`${this.baseURL}/${User.PersonID}`, User);
  }

  deleteUser(ID: number) {
    return this.http.delete(`${this.baseURL}/${ID}`);
  }
}

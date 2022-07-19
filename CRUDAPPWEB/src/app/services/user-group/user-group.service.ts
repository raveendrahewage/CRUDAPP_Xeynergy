import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

interface UserGroup {
  UserGroupID: number;
  GroupName: string;
  AccessRuleID: number;
}

@Injectable({
  providedIn: 'root',
})
export class UserGroupService {
  constructor(private http: HttpClient) {}
  readonly baseURL = 'https://localhost:44364/api/usergroup';

  getAllUserGroups() {
    return this.http.get(`${this.baseURL}`);
  }

  getUserGroupByID(ID: number) {
    return this.http.get(`${this.baseURL}/${ID}`);
  }

  postUserGroup(UserGroup: UserGroup) {
    return this.http.post(`${this.baseURL}`, UserGroup);
  }

  putUserGroup(UserGroup: UserGroup) {
    return this.http.put(`${this.baseURL}/${UserGroup.UserGroupID}`, UserGroup);
  }

  deleteUserGroup(ID: number) {
    return this.http.delete(`${this.baseURL}/${ID}`);
  }
}

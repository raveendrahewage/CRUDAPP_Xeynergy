import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

interface AccessRule {
  AccessRuleID: number;
  RuleName: string;
  Permission: boolean;
}

@Injectable({
  providedIn: 'root',
})
export class AccessRuleService {
  constructor(private http: HttpClient) {}
  readonly baseURL = 'https://localhost:44364/api/accessrule';

  getAllAccessRules() {
    return this.http.get(`${this.baseURL}`);
  }

  getAccessRuleByID(ID: number) {
    return this.http.get(`${this.baseURL}/${ID}`);
  }

  postAccessRule(AccessRule: AccessRule) {
    return this.http.post(`${this.baseURL}`, AccessRule);
  }

  putAccessRule(AccessRule: AccessRule) {
    return this.http.put(
      `${this.baseURL}/${AccessRule.AccessRuleID}`,
      AccessRule
    );
  }

  deleteAccessRule(ID: number) {
    return this.http.delete(`${this.baseURL}/${ID}`);
  }

  getAccessRuleUsers(ID:number) {
    return this.http.get(`${this.baseURL}/userList/${ID}`);
  }
}

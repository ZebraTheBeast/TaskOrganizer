import { HttpHeaders, HttpClient } from "@angular/common/http";
import { Injectable } from '@angular/core';
import { Observable, of } from 'rxjs';


const httpOptions = {
  headers: new HttpHeaders({ 'Content-Type': 'application/json' })
};

@Injectable({ providedIn: 'root' })
export class AccountService {
  private accountdUrl = '/api/account';
  constructor(private http: HttpClient) { }

  login(username: string, password: string): Observable<any> {
    const url = `${this.accountdUrl}/LogIn`;
    var request = {
      username: username,
      password: password
    }
    return this.http.post<any>(url, request, httpOptions);
  }
}

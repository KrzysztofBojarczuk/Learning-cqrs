import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { LoginUser } from '../models/loginUser';

@Injectable({
  providedIn: 'root',
})
export class AuthService {
  private apiUrl = 'https://localhost:7145/';

  constructor(private http: HttpClient) {}

  registerUserService(registerUser: any): Observable<any> {
    return this.http.post<any>(`${this.apiUrl}register/`, registerUser);
  }

  loginUserService(loginUser: LoginUser): Observable<{ token: string }> {
    return this.http.post<{ token: string }>(`${this.apiUrl}login/`, loginUser);
  }
}

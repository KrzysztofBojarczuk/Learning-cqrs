import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { LoginUser } from '../models/loginUser';
import { RegisterUser } from '../models/registerUser';

@Injectable({
  providedIn: 'root',
})
export class AuthService {
  private apiUrl = 'https://localhost:7145/';

  constructor(private http: HttpClient) {}

  loginUserService(loginUser: LoginUser): Observable<{ accessToken: string }> {
    return this.http.post<{ accessToken: string }>(
      `${this.apiUrl}login`,
      loginUser
    );
  }

  registerUserService(registerUser: RegisterUser): Observable<void> {
    return this.http.post<void>(`${this.apiUrl}register`, registerUser);
  }
}

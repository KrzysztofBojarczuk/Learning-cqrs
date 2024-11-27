import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Employee } from '../models/employee';

@Injectable({
  providedIn: 'root',
})
export class EmployeeService {
  private apiUrl = 'https://localhost:7145/api/Employees';

  constructor(private http: HttpClient) {}

  getAllEmployee(): Observable<Employee[]> {
    return this.http.get<Employee[]>(this.apiUrl);
  }
}

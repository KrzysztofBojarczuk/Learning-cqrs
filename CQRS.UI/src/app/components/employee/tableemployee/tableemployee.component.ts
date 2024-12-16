import { Component } from '@angular/core';

import { MatTableDataSource, MatTableModule } from '@angular/material/table';
import { Employee } from '../../../models/employee';
import { EmployeeService } from '../../../services/employee.service';

@Component({
  selector: 'app-tableemployee',
  imports: [MatTableModule],
  templateUrl: './tableemployee.component.html',
  styleUrl: './tableemployee.component.scss',
})
export class TableemployeeComponent {
  dataSource: MatTableDataSource<Employee>;

  employee: Employee[] = [];

  displayedColumns: string[] = ['id', 'name', 'email', 'phone'];

  constructor(private employeeService: EmployeeService) {
    this.dataSource = new MatTableDataSource<Employee>([]);
  }

  ngOnInit() {
    this.getAllEmployee();
  }

  getAllEmployee() {
    this.employeeService
      .getAllEmployee()
      .subscribe(
        (result) => (this.dataSource = new MatTableDataSource(result))
      );
  }
}

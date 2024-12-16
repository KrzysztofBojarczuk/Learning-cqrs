import { Routes } from '@angular/router';
import { LoginComponent } from './authentication/login/login.component';
import { TabletaskComponent } from './components/task/tabletask/tabletask.component';
import { TableemployeeComponent } from './components/employee/tableemployee/tableemployee.component';
import { RegisterComponent } from './authentication/register/register.component';

export const routes: Routes = [
  {
    path: 'login',
    component: LoginComponent,
  },
  {
    path: 'register',
    component: RegisterComponent,
  },
  {
    path: 'employee',
    component: TableemployeeComponent,
  },
  {
    path: 'task',
    component: TabletaskComponent,
  },
];

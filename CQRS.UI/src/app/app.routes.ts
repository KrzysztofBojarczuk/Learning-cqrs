import { RouterModule, Routes } from '@angular/router';
import { LoginComponent } from './authentication/login/login.component';
import { TabletaskComponent } from './components/task/tabletask/tabletask.component';
import { TableemployeeComponent } from './components/employee/tableemployee/tableemployee.component';
import { RegisterComponent } from './authentication/register/register.component';
import { AuthGuard } from './guards/auth.guard';
import { NgModule } from '@angular/core';

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
    canActivate: [AuthGuard],
  },
  {
    path: 'task',
    component: TabletaskComponent,
    canActivate: [AuthGuard],
  },
  { path: 'task', component: TabletaskComponent, canActivate: [AuthGuard] },
  { path: '', redirectTo: 'login', pathMatch: 'full' },
  { path: '**', redirectTo: 'login' },
];

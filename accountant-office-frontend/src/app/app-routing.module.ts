import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { DepartmentModule } from './department/department.module';
import { DepartmentsComponent } from './department/departments/departments.component';
import { ViewDepartmentComponent } from './department/view-department/view-department.component';

const routes: Routes = [
  { path: 'departments', component: DepartmentsComponent},
  { path: 'departments/:id', component: ViewDepartmentComponent},
  { path: '**', redirectTo: 'departments'},
];

@NgModule({
  imports: [
    RouterModule.forRoot(routes),
    DepartmentModule
  ],
  exports: [RouterModule]
})
export class AppRoutingModule { }

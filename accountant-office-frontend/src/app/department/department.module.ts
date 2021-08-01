import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { DepartmentsComponent } from './departments/departments.component';
import { NewDepartmentComponent } from './new-department/new-department.component';
import { ViewDepartmentComponent } from './view-department/view-department.component';
import { MatTableModule } from '@angular/material/table';
import { MatButtonModule } from '@angular/material/button';
import { MatButtonToggleModule } from '@angular/material/button-toggle';
import { MatIconModule } from '@angular/material/icon';
import { ApiDepartmentService } from './services/api-department.service';
import { MatDialogModule } from '@angular/material/dialog';
import { FormsModule } from '@angular/forms';
import { MatInputModule } from '@angular/material/input';
import { NewEmployeeComponent } from './new-employee/new-employee.component';
import { MatPaginatorModule } from '@angular/material/paginator';

@NgModule({
  declarations: [
    DepartmentsComponent,
    NewDepartmentComponent,
    ViewDepartmentComponent,
    NewEmployeeComponent
  ],
  imports: [
    CommonModule,
    MatButtonModule,
    MatButtonToggleModule,
    MatTableModule,
    MatIconModule,
    MatDialogModule,
    MatInputModule,
    MatPaginatorModule,
    FormsModule
  ],
  providers: [
    ApiDepartmentService
  ]
})
export class DepartmentModule { }

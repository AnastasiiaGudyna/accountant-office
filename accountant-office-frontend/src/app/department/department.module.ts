import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import {
  DepartmentsComponent,
  CatalogsComponent,
  NewDepartmentComponent,
  ViewDepartmentComponent,
  NewEmployeeComponent
} from './components';
import { MatTableModule } from '@angular/material/table';
import { MatButtonModule } from '@angular/material/button';
import { MatButtonToggleModule } from '@angular/material/button-toggle';
import { MatIconModule } from '@angular/material/icon';
import { ApiDepartmentService } from './services/api-department.service';
import { MatDialogModule } from '@angular/material/dialog';
import { FormsModule } from '@angular/forms';
import { MatInputModule } from '@angular/material/input';
import { MatPaginatorModule } from '@angular/material/paginator';
import { MatTabsModule } from '@angular/material/tabs';
import { ApiCatalogService } from './services/api-catalog.service';

@NgModule({
  declarations: [
    DepartmentsComponent,
    NewDepartmentComponent,
    ViewDepartmentComponent,
    NewEmployeeComponent,
    CatalogsComponent
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
    MatTabsModule,
    FormsModule
  ],
  providers: [
    ApiDepartmentService,
    ApiCatalogService
  ]
})
export class DepartmentModule { }

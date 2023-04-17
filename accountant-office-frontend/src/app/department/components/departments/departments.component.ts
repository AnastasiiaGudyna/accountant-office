import { Component, OnInit } from '@angular/core';
import {  Router } from '@angular/router';
import { ApiDepartmentService } from '../../services/api-department.service';
import { MatDialog } from '@angular/material/dialog';
import { NewDepartmentComponent } from '../new-department/new-department.component';
import { Department } from '../../models/department.model';
import { PageEvent } from '@angular/material/paginator';
import { AuthService } from 'src/app/core/services/auth.service';

@Component({
  selector: 'app-departments',
  templateUrl: './departments.component.html',
  styleUrls: ['./departments.component.less']
})
export class DepartmentsComponent implements OnInit {

  public dataSource: Array<any> = [];
  displayedColumns: string[] = ['name', 'avr_salary', 'employees_count', 'actions'];
  public length = 100;
  public pageSize = 10;
  public pageSizeOptions: number[] = [5, 10, 25, 100];

  constructor(
    private router: Router,
    private authService: AuthService,
    private api: ApiDepartmentService,
    public dialog: MatDialog) { }

  public ngOnInit(): void {
    this.api.getDepartments(0, this.pageSize).subscribe(deps => {
      this.dataSource = deps.departments; this.length = deps.departmentsCount;
    });
  }

  public goToDepartment(id: string): void {
    this.router.navigate([`/departments/${id}`]);
  }

  public create(): void {
    this.openDialog(
      (result: Department) => {
        this.api.put(result).subscribe((id) => this.dataSource = [...this.dataSource,
          {name: result.name, id: id, averageSalary: 0, employessCount: 0}]);
        });
  }

  public update(item: Department): void {
    this.openDialog(
      (result: Department) => {
        this.api.post(result).subscribe((id) => 
        this.dataSource = [...this.dataSource.filter(d => d.id !== id), {...result}]);
      },
      {...item});
  }

  public delete(id: string): void {
    this.api.delete(id);
  }

  public changedPageOptions(pageOpts: PageEvent): void {
    this.api.getDepartments(pageOpts.pageIndex, pageOpts.pageSize)
    .subscribe(items => this.dataSource = items);
  }

  public renew(){
    this.authService.renewToken().subscribe();
  }

  private openDialog(action: (res: any) => any, data: any = {}): void {
    const dialogRef = this.dialog.open(NewDepartmentComponent, {
      width: '300px',
      data: data
    });

    dialogRef.afterClosed().subscribe(result => {
      if(result) {
        action(result); // save department
      }
    });
  }
}

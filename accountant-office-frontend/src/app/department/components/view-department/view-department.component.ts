import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Department } from '../../models/department.model';
import { Employee } from '../../models/employee.model';
import { ApiDepartmentService } from '../../services/api-department.service';
import { ApiEmployeeService } from '../../services/api-employee.service';
import { MatDialog } from '@angular/material/dialog';
import { NewEmployeeComponent } from '../new-employee/new-employee.component';
import { PageEvent } from '@angular/material/paginator';

@Component({
  selector: 'app-view-department',
  templateUrl: './view-department.component.html',
  styleUrls: ['./view-department.component.less']
})
export class ViewDepartmentComponent implements OnInit {
  public department: Department | undefined;
  public dataSource: Array<any> = [];
  public displayedColumns: string[] = ['id', 'name', 'surname', 'salary', 'actions'];
  public length = 100;
  public pageSize = 10;
  public pageSizeOptions: number[] = [5, 10, 25, 100];
  
  constructor(private route: ActivatedRoute,
    private apiDepartment: ApiDepartmentService,
    private apiEmployee: ApiEmployeeService,
    public dialog: MatDialog) { }

  public ngOnInit(): void {
    this.route.paramMap.subscribe(params => {
      const id = params.get("id") ?? "";
      this.apiDepartment.getDepartment(id).subscribe(item => this.department = item);
      this.apiDepartment.getEmployeesOfDepartment(id, 0, this.pageSize).subscribe(items => this.dataSource = items);
    });
  }

  public create(): void {
    this.openDialog(
      (result: Employee) => {
        this.apiEmployee.put({...result, departmentId: this.department?.id}).subscribe((id) => this.dataSource = [...this.dataSource,
          {...result, id: id}]);
        });
  }

  public update(item: Employee): void {
    this.openDialog(
      (result: Employee) => {
        this.apiEmployee.post(result).subscribe((id) => 
        this.dataSource = [...this.dataSource.filter(d => d.id !== id), {...result}]);
      },
      {...item, departmentId: this.department?.id});
  }

  public delete(id: string): void {
    this.apiEmployee.delete(id).subscribe(() => this.dataSource = [...this.dataSource.filter(d => d.id !== id)]);
  }

  public changedPageOptions(pageOpts: PageEvent): void {
    this.apiDepartment.getEmployeesOfDepartment(this.department?.id ?? "", pageOpts.pageIndex, pageOpts.pageSize)
    .subscribe(items => this.dataSource = items);
  }

  private openDialog(action: (res: any) => any, data: any = {}): void {
    const dialogRef = this.dialog.open(NewEmployeeComponent, {
      width: '300px',
      data: data
    });

    dialogRef.afterClosed().subscribe(result => {
      if(result) {
        action(result); // save employee
      }
    });
  }
}


import { Component, Inject } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { Employee } from '../models/employee.model';

@Component({
  selector: 'app-new-employee',
  templateUrl: './new-employee.component.html',
  styleUrls: ['./new-employee.component.less']
})
export class NewEmployeeComponent {

  constructor(
    public dialogRef: MatDialogRef<NewEmployeeComponent>,
    @Inject(MAT_DIALOG_DATA) public data: Employee) {}

  public onNoClick(): void {
    this.dialogRef.close();
  }
}

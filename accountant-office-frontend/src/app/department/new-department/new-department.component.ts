import { Component, Inject } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { Department } from '../models/department.model';

@Component({
  selector: 'app-new-department',
  templateUrl: './new-department.component.html',
  styleUrls: ['./new-department.component.less']
})
export class NewDepartmentComponent {

  constructor(
    public dialogRef: MatDialogRef<NewDepartmentComponent>,
    @Inject(MAT_DIALOG_DATA) public data: Department) {}

  public onNoClick(): void {
    this.dialogRef.close();
  }
}

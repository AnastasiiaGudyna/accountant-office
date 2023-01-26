import { Component, Inject, OnInit } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { Employee } from '../../models/employee.model';
import { ApiCatalogService } from '../../services/api-catalog.service';

@Component({
  selector: 'app-new-employee',
  templateUrl: './new-employee.component.html',
  styleUrls: ['./new-employee.component.less']
})
export class NewEmployeeComponent implements OnInit {

  public jobCategories: Array<any> = [];
  constructor(
    public dialogRef: MatDialogRef<NewEmployeeComponent>,
    @Inject(MAT_DIALOG_DATA) public data: Employee,
    private catalogService: ApiCatalogService
    ) { }
    
  ngOnInit(): void {
    //this.catalogService.get(Catalog.JobCategory).subscribe(items => this.jobCategories = items);
  }
    
  public onNoClick(): void {
    this.dialogRef.close();
  }
}

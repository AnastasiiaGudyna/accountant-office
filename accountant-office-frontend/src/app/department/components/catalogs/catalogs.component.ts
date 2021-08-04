import { Component, OnInit } from '@angular/core';
import { ApiCatalogService } from '../../services/api-catalog.service';

@Component({
  selector: 'app-catalogs',
  templateUrl: './catalogs.component.html',
  styleUrls: ['./catalogs.component.less']
})
export class CatalogsComponent implements OnInit {

  public jobCategories: Array<any> = [];
  constructor(private service: ApiCatalogService) { }

  ngOnInit(): void {
    this.getJobs();
  }
  public addNewItem(): void {
    this.jobCategories.push({new: true});
  }

  public save(item: any): void {
    this.service.put(item)
    .subscribe(result => {
      item.new = false;
    });
  }

  public delete(id: string): void {
    this.service.delete(id)
    .subscribe(() => {
      this.jobCategories = this.jobCategories.filter(c => c.id !== id);
    });
  }

  private getJobs(): void {
    this.service.getJobCategories().subscribe(items => this.jobCategories = items);
  }
}

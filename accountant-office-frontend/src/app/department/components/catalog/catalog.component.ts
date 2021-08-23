import { Component, Input, OnInit } from '@angular/core';
import { ApiCatalogService, Catalog } from 'src/app/department/services/api-catalog.service';

@Component({
  selector: 'app-catalog',
  templateUrl: './catalog.component.html',
  styleUrls: ['./catalog.component.less']
})
export class CatalogComponent implements OnInit {

  public catalogArray: Array<any> = [];
  @Input()
  public catalog: Catalog = Catalog.JobCategory;

  constructor(private service: ApiCatalogService) { }

  ngOnInit(): void {
    this.getAll();
  }
  public addNew(): void {
    this.catalogArray.push({new: true});
  }

  public save(item: any): void {
    this.service.put(this.catalog, item)
    .subscribe(result => {
      item.new = false;
    });
  }

  public delete(id: string): void {
    this.service.delete(this.catalog, id)
    .subscribe(() => {
      this.catalogArray = this.catalogArray.filter(c => c.id !== id);
    });
  }

  private getAll(): void {
    this.service.get(this.catalog).subscribe(items => this.catalogArray = items);
  }
}

import { Component, Input, OnInit } from '@angular/core';
import { ApiCatalogService } from 'src/app/department/services/api-catalog.service';
import { Catalog } from '../../models/catalog.model';

@Component({
  selector: 'app-catalog',
  templateUrl: './catalog.component.html',
  styleUrls: ['./catalog.component.less']
})
export class CatalogComponent implements OnInit {

  @Input()
  public catalog!: Catalog;

  constructor(private service: ApiCatalogService) { }

  ngOnInit(): void {  }

  public addNew(): void {
    this.catalog.catalogValues.push({new: true});
  }

  public save(item: any): void {
    this.service.put(this.catalog.id, item)
    .subscribe(result => {
      item.new = false;
      item.id = result;
    });
  }

  public delete(id: string | undefined): void {
    if(id != undefined) {
      this.service.delete(this.catalog.id, id)
      .subscribe(() => {
        this.catalog.catalogValues = this.catalog.catalogValues.filter(c => c.id !== id);
      });
    }
  }
}

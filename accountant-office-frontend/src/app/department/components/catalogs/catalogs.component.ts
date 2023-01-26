import { Component, OnInit } from '@angular/core';
import { Catalog } from '../../models/catalog.model';
import { ApiCatalogService } from '../../services/api-catalog.service';

@Component({
  selector: 'app-catalogs',
  templateUrl: './catalogs.component.html',
  styleUrls: ['./catalogs.component.less']
})

export class CatalogsComponent implements OnInit{
  public catalogs: Array<Catalog> = [];
  constructor(private service: ApiCatalogService){}
  
  ngOnInit(): void {
    this.service.getAll().subscribe(items => this.catalogs = items);
  }
}

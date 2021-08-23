import { Component } from '@angular/core';
import { Catalog } from '../../services/api-catalog.service';

@Component({
  selector: 'app-catalogs',
  templateUrl: './catalogs.component.html',
  styleUrls: ['./catalogs.component.less']
})

export class CatalogsComponent {

  public catalogEnum: typeof Catalog = Catalog;

}

import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
export enum Catalog {
  JobCategory = 'job-categories',
  Skill = 'skills'
}
@Injectable({
  providedIn: 'root'
})
export class ApiCatalogService {
  private path = 'catalogs';

  constructor(private http: HttpClient) { }

  public get(catalog: Catalog): Observable<Array<any>> {
    return this.http.get<Array<any>>(`${this.path}/${catalog}`);
  }

  public put(catalog: Catalog, item: any) {
    return this.http.put<any>(`${this.path}/${catalog}`, item);
  }

  public delete(catalog: Catalog, id: string) {
    return this.http.delete<any>(`${this.path}/${catalog}/${id}`);
  }
}

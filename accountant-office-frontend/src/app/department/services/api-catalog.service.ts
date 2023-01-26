import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ApiCatalogService {
  private path = 'catalogs';

  constructor(private http: HttpClient) { }

  public get(catalogId: string): Observable<any> {
    return this.http.get<Array<any>>(`${this.path}/${catalogId}`);
  }

  public getAll(): Observable<Array<any>> {
    return this.http.get<Array<any>>(`${this.path}`);
  }

  public put(catalogId: string, item: any) {
    return this.http.put<any>(`${this.path}/${catalogId}/catalog-value`, item);
  }

  public delete(catalogId: string, id: string) {
    return this.http.delete<any>(`${this.path}/${catalogId}/catalog-value/${id}`);
  }
}

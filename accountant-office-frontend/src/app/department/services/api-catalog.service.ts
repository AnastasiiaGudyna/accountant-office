import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ApiCatalogService {
  private path = 'catalogs';

  constructor(private http: HttpClient) { }

  public getJobCategories(): Observable<Array<any>> {
    return this.http.get<Array<any>>(`${this.path}/job-categories`);
  }

  public put(item: any) {
    return this.http.put<any>(`${this.path}/job-categories`, item);
  }

  public delete(id: string) {
    return this.http.delete<any>(`${this.path}/job-categories/${id}`);
  }
}

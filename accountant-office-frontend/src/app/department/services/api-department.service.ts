import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ApiDepartmentService {

  constructor(private http: HttpClient) { }

  public getDepartments(page: number, itemsOnPage: number): Observable<Array<any>> {
    return this.http.get<Array<any>>(`departments`, { params: {page, itemsOnPage } });
  }

  public getDepartment(id: string): Observable<any> {
    return this.http.get<any>(`departments/${id}`);
  }

  public getEmployeesOfDepartment(id: string, page: number, itemsOnPage: number): Observable<any> {
    return this.http.get<any>(`departments/${id}/employees`, { params: {page, itemsOnPage } });
  }

  public put(item: any) {
    return this.http.put<any>(`departments`, item);
  }

  public post(item: any) {
    return this.http.post<any>(`departments/${item.id}`, item);
  }

  public delete(id: string) {
    return this.http.delete<any>(`departments/${id}`);
  }
}

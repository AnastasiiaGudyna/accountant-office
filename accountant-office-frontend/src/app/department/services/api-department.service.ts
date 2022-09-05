import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ApiDepartmentService {
  private departmentPath = 'departments';

  constructor(private http: HttpClient) { }

  public getDepartments(page: number, itemsOnPage: number): Observable<any> {
    return this.http.get<any>(this.departmentPath, { params: { page, itemsOnPage } });
  }

  public getDepartment(id: string): Observable<any> {
    return this.http.get<any>(`${this.departmentPath}/${id}`);
  }

  public getEmployeesOfDepartment(id: string, page: number, itemsOnPage: number): Observable<any> {
    return this.http.get<any>(`${this.departmentPath}/${id}/employees`, { params: { page, itemsOnPage } });
  }

  public put(item: any) {
    return this.http.put<any>(this.departmentPath, item);
  }

  public post(item: any) {
    return this.http.post<any>(`${this.departmentPath}/${item.id}`, item);
  }

  public delete(id: string) {
    return this.http.delete<any>(`${this.departmentPath}/${id}`);
  }
}
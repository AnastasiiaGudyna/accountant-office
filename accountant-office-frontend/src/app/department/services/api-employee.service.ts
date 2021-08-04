import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class ApiEmployeeService {

  constructor(private http: HttpClient) { }

  public put(item: any) {
    return this.http.put<any>(`employees`, item);
  }

  public post(item: any) {
    return this.http.post<any>(`employees/${item.id}`, item);
  }

  public delete(id: string) {
    return this.http.delete<any>(`employees/${id}`);
  }
}

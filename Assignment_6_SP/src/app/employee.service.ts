import { Injectable } from '@angular/core';
import{HttpClient}from '@angular/common/http';
import { Observable } from 'rxjs';
import { Employee } from './employee';


@Injectable({
  providedIn: 'root'
})
export class EmployeeService {

  constructor(private httpclient:HttpClient) {}

  getEmployee(PageNo:number,pagesize:number,SearchColumn:string,SearchValue:string,SortColumn:string,SortOrder:string):Observable<any>{
    return this.httpclient.get<any>("https://localhost:44363/api/Employee?PageNo="+PageNo+"&pagesize="+pagesize+"&SearchColumn="+SearchColumn+"&SearchValue="+SearchValue+"&SortColumn="+SortColumn+"&ShortOrder="+SortOrder);
  }

  saveEmployee(newEmployee:Employee):Observable<Employee>
  {
    return this.httpclient.post<Employee>("https://localhost:44363/api/Employee",newEmployee);
  }

  UpdateEmployee(editEmployee:Employee):Observable<Employee>
  {
    return this.httpclient.put<Employee>("https://localhost:44363/api/Employee",editEmployee);
  }

  deleteEmployee(id:number):Observable<any>
  {
    return this.httpclient.delete<any>
    ("https://localhost:44363/api/Employee/"+id);
  }
}

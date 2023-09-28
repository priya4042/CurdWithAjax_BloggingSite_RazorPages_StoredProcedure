import { Component, OnInit } from '@angular/core';
import { HttpClient, HttpResponse } from '@angular/common/http';
import { Employee } from './employee';
import { EmployeeComponent } from './employee/employee.component';


@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent implements OnInit {
  title = 'Assignment_6_SP';
  data:any;
  SearchColumn:string;  
  SearchValue:string;
  PageNo:number;
  PageSize:number;
  SortColumn:string;
  SortOrder:string;

  dtOptions: DataTables.Settings = {};
  results: any = [];
  displaying_results: any = [];
  displaying_results2: any = [];
  start: any = [];
  end: any = [];
  pageInfo: any = {};
  dtTrigger1: Employee = new Employee();

 
  employee:Employee[]=[]

  constructor(private http: HttpClient) {
    this.SearchColumn="";
    this.SearchValue="";
    this.PageNo=0;  
    this.PageSize=0;
    this.SortColumn="";
    this.SortOrder="";}

  ngOnInit(): void {
    const that = this;

    this.dtOptions = {
      pagingType: 'full_numbers',
      pageLength: 2,
      
      serverSide: true,
      processing: true,
      ajax: (dataTablesParameters: any, callback) => {
        that.http
          .post<AppComponent>(
            'https://localhost:44363/api/Employee',
            
            dataTablesParameters, {}
          ).subscribe(resp => {
            that.employee = resp.data;

            callback({
              SearchColumn:resp.SearchColumn,
              SearchValue:resp.SearchValue,
              PageNo:resp.PageNo,
              PageSize:resp.PageSize,
              SortColumn:resp.SortColumn,
              SortOrder:resp.SortOrder,
              data: []
            });
          });
      },
      columns: [{ data: 'id'   }, { data: 'Name' }, { data: 'Number' },{ data: 'Address' },{ data: 'Salary' }]
    };
  }
}


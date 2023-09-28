
import { Component, OnInit } from '@angular/core';
import { HttpClient, HttpResponse } from '@angular/common/http';
import { Employee } from './employee';


export class DataTablesResponse {
data:any;
  SearchColumn:string;
  SearchValue:string;
  PageNo:number;
  PageSize:number;
  SortColumn:string;
  SortOrder:string;

  constructor()
  {
    this.SearchColumn="";
    this.SearchValue="";
    this.PageNo=0;
    this.PageSize=0;
    this.SortColumn="";
    this.SortOrder="";
  }
}

@Component({
  selector: 'app-server-side-angular-way',
  templateUrl: 'server-side-angular-way.component.html',
  styleUrls: ['server-side-angular-way.component.css']
})
export class ServerSideAngularWayComponent implements OnInit {

  dtOptions: DataTables.Settings = {};
  employee:Employee[]=[]

  constructor(private http: HttpClient) {}

  ngOnInit(): void {
    const that = this;

    this.dtOptions = {
      pagingType: 'full_numbers',
      pageLength: 2,
      serverSide: true,
      processing: true,
      ajax: (dataTablesParameters: any, callback) => {
        that.http
          .post<DataTablesResponse>(
            'https://localhost:44363/api/Employee?PageNo="+PageNo+"&pagesize="+pagesize+"&SearchColumn="+SearchColumn+"&SearchValue="+SearchValue+"&SortColumn="+SortColumn+"&ShortOrder="+SortOrder',
            
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
      columns: [{ data: 'id' }, { data: 'Name' }, { data: 'Number' },{ data: 'Address' },{ data: 'Salary' }]
    };
  }
}
 
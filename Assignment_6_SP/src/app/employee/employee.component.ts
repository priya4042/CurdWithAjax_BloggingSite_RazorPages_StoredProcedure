import { Component, OnInit } from '@angular/core';
import { Subject } from 'rxjs';
import { DatatableServer } from '../datatable-server';
import { Employee } from '../employee';
import { EmployeeService } from '../employee.service';
import { DataTableDirective } from "angular-datatables";    
import { timer } from 'rxjs';    
import { HttpClient } from '@angular/common/http';
import { __values } from 'tslib';



@Component({
  selector: 'app-employee',
  templateUrl:'./employee.component.html',
  styleUrls: ['./employee.component.scss']
})
export class EmployeeComponent implements OnInit {

  EmployeeList:Employee[]=[];
  Employee:Employee=new Employee();

  dtOptions:DataTables.Settings={};
  dtTrigger:Subject<any>=new Subject<any>();

  

  PageNo:any=1;
  PazeSize=12;
  PageSizeArr=[4,8,12];
  TotalItem:number|undefined;
  filterTerm:string='';
  sortColumn:string="F_Name";
  SortOrder:string="asc";

  

  constructor(private employeeService:EmployeeService, public httpClient:HttpClient  ) { }

  ngOnInit(): void {
    this.dtOptions={
     pagingType:'full_numbers',
     pageLength:5,
     processing:true,
     lengthMenu:[2,4,8],

    

     ajax: 'https://localhost:44363/api/Employee?PageNo="+PageNo+"&pagesize="+pagesize+"&SearchColumn="+SearchColumn+"&SearchValue="+SearchValue+"&SortColumn="+SortColumn+"&ShortOrder="+SortOrder',
      columns: [{
        title: 'ID',
        data: 'id'
      }, {
        title: 'Name',
        data: 'Name'
      }, {
        title: 'Number',
        data: 'Number'
      },
      {
        title: 'Address',
        data: 'Address'
      },
      {
        title: 'Salary',
        data: 'Salary'
      }]
      
    }

    this.httpClient.get<Employee[]>('data/data.json')
    .subscribe(data => {
      this.Employee = (data as any).data;
      // Calling the DT trigger to manually render the table
      this.dtTrigger.next(Employee);
    });

    this.getAll();
    
  
  }
  ngOnDestroy(): void {
    // Do not forget to unsubscribe the event
    this.dtTrigger.unsubscribe();
  }

  PageChangeEvent(event:any){
    debugger
    this.PageNo=event;
    this.getAll();
  }
  
  tableData(event:any):void{
    debugger
    this.PazeSize=event.target.value;
    this.PageNo=1;
    this.getAll();
  }

  searchItem(event:any){
    this.filterTerm=event.target.value;
    this.getAll();
  }

  sortData(col:any):void {
    debugger
    if(this.sortColumn==col)
    if(this.SortOrder='asc')
    (this.SortOrder='dsc')
  }
  
 
  getAll()
{
  this.employeeService.getEmployee(1,10,"","","","").subscribe(
    (response)=>{
      this.EmployeeList=response;
      console.log(response);
    },
    (error)=>{
      console.log(error);
    }
  );
}
SaveClick()
{
  this.Employee.id=0;
   
  this.employeeService.saveEmployee(this.Employee).subscribe(
    (response)=>{

      this.getAll();
      this.Employee.name="";
      this.Employee.number="";
      this.Employee.address="";
      this.Employee.salary="";
    },
    (error)=>{
      console.log(error);
    }
  );
} 

 editClick(emp:any)
{
  this.Employee=emp;
  //alert(this.editStudent.name);
}

updateClick()
{
// alert(this.editStudent.name)
this.employeeService.UpdateEmployee(this.Employee).subscribe(
  (Response)=>{
    this.getAll();
  },
  (error)=>{
    console.log(error)
  }
)
}
deleteClick(id:number)
{
  let ans=confirm('want to delete data?');
  
  if(!ans) return;
  
  this.employeeService.deleteEmployee(id).subscribe(
    (Response)=>{
      this.getAll();
    },
  (error)=>{
    console.log(error);
  }
  )
}



}

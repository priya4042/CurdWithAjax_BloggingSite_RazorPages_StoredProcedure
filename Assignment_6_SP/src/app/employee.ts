export class Employee {
  id: any;
  name:any;
  number:any;
  address:any;
  salary:any;

  SearchColumn:string;
  SearchValue:string;
  PageNo:number;
  PageSize:number;
  SortColumn:string;
  SortOrder:string;

  constructor()
  {
    this.id=null;
    this.name=null;
    this.number=null;
    this.address=null;
    this.salary=null;

    this.SearchColumn="";
    this.SearchValue="";
    this.PageNo=1;
    this.PageSize=10;
    this.SortColumn="";
    this.SortOrder="";
  }
}

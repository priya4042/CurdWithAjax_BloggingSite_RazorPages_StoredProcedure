export class DatatableServer {
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

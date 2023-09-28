import { Injectable } from '@angular/core';
import{HttpClient} from '@angular/common/http';
import { Register } from './register';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class RegisterService {

  constructor(private httpclient:HttpClient) { }

  saveReg(newReg:Register):Observable<Register>
  {
    return this.httpclient.post<Register>("https://localhost:44328/api/Register/Api/Login/createcontact",newReg);
  }

  
}

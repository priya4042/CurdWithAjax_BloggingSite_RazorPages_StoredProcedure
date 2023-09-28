import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { JwtHelperService } from  '@auth0/angular-jwt';

import { map, Observable } from 'rxjs';
import { Login } from './login';

@Injectable({
  providedIn: 'root'
})
export class LoginService {
  currentUsername:any="";
    constructor(private httpClient:HttpClient,private router:Router) { }
  
    checkuser(user:Login):Observable<Login>
    {
      return this.httpClient.post<Login>('https://localhost:44328/api/Register/Api/Login/UserLogin',user)
      .pipe(map(u=>{
  if(u)
  {
    this.currentUsername=u.username;
    sessionStorage['currentUser']=JSON.stringify(u);
  }
  return u;
      }))
      
    }
    logout()
    {
      this.currentUsername="";
      sessionStorage.removeItem('currentUser');
      this.router.navigateByUrl("/login");
    }
    public isAuthenticate():boolean
    {
     if(this.isAuthenticate())
     {
       return false;
     }
     else
     {
       return true;
     }
    }
  }
  
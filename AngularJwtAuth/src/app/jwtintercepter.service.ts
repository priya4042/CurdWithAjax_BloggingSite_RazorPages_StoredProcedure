import { HttpEvent, HttpHandler, HttpInterceptor, HttpRequest } from '@angular/common/http';
import { Injectable } from '@angular/core';

import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class JwtintercepterService  implements HttpInterceptor 
{

  constructor() { }
  intercept(request: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
    var currentUser={token:""};
    var currentUserSession=sessionStorage.getItem('currentUser');
    if(currentUserSession!=null)
    {
      currentUser=JSON.parse(currentUserSession);
    }
    request=request.clone({
      setHeaders:{
        Authorization:"Bearer" +currentUser.token
      }
    });
    return next.handle(request);
  }
}

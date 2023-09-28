import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class CanactivategaurdServiceService {

  // constructor(private loginService:LoginService,private router:Router,private jwtHelperService:JwtHelperService) { }
  // canActivate(route: ActivatedRouteSnapshot, state: RouterStateSnapshot): boolean {
  //   var token=sessionStorage.getItem('currentUser')?JSON.parse(sessionStorage.getItem('currentUser')as string).token:null
  //   if(this.loginService.isAuthenticate())
  //   {
  //     return true;
  //   }
  //   else
  //   {
  //     this.router.navigateByUrl("/login");
  //     return false;
  //   }
  // }
}

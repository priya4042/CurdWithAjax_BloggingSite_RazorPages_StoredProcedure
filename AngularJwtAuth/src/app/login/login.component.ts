import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Login } from '../login';
import { LoginService } from '../login.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent implements OnInit {
userlogin:Login=new Login();
loginError:string="";
  constructor(private Loginservice:LoginService,private router:Router) { }

  ngOnInit(): void {
  }

  onLoginClick(event:any){
    this.Loginservice.checkuser(this.userlogin).subscribe
    (
        (Response)=>{
          if(Response)=
          {
            this.router.navigateByUrl("/my-profile");
          }
          else{
            this.loginError="Username or Password Incorrect";
          }
        }
    )
  }

}

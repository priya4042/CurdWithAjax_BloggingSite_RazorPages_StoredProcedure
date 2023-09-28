import { Component, OnInit } from '@angular/core';
import { Register } from '../register';
import { RegisterService } from '../register.service';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.scss']
})
export class RegisterComponent implements OnInit {

  RegisterList:Register[]=[];

  constructor(private registerService:RegisterService) { }

  ngOnInit(): void {
    //this.Post();
  }
  // Post()
  // {
  //   this.registerService.saveReg().subscribe(
  //     (Response)=>{
  //       this.RegisterList=response;
  //     },
  //     (error)=>{
  //       console.log(error);
  //     }
  //   )
  // };

}

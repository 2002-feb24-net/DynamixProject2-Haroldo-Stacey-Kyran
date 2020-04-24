import { Component, OnInit } from '@angular/core';
import { FormGroup, Validators, FormBuilder } from '@angular/forms';
import { Router } from '@angular/router';
import {UserService} from 'src/app/shared/user.service';
@Component({
  selector: 'app-sign-in',
  templateUrl: './sign-in.component.html',
  styleUrls: ['./sign-in.component.css']
})
export class SignInComponent implements OnInit {
  Username:string = "";
  userPass:string = "";
  logInError:boolean = false;

  constructor(
    private service: UserService,
    private router:Router

  ) { }

  ngOnInit() {

  }

  onSubmit() {
    this.service.getUser(this.Username)
        .then(resp=> {
          debugger;
          if(resp[0].Password.trim()==this.userPass){
            this.service.loggedIn=true;
            this.router.navigate(['/home']);
          } else {
            this.logInError = true;
            // this.router.navigate(['/main']);
          }
        })
        .catch((err)=>{
          console.log(err);
          this.logInError=true
        })
  }
}

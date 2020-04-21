import { Component, OnInit } from '@angular/core';
import {HttpService} from '../http.service';
import { ActivatedRoute, Router } from '@angular/router';

function userAccount(){
  return{
    Name: '',
    Email: '',
    Password: ''
  }
}


function sendErrorMessages(errors: any): Array<string> {
  let result: Array<string> = [];
  errors.array.forEach(e => {
    result.push(e);
  });
  return result;
}



@Component({
  selector: 'app-about',
  templateUrl: './about.component.html',
  styleUrls: ['./about.component.css']
})
export class AboutComponent implements OnInit {
  userLogin: any;
  userReg: any;
  messages: Array<string>;
  flash: boolean;

  constructor(
    private _http: HttpService,
    private _route: ActivatedRoute,
    private _router: Router
  ) { }

  ngOnInit(): void {
    this.userLogin = userAccount();
    this.userReg = userAccount();
    this.messages = [];
    this.flash = false;
  }

  uLogin() {
    this.messages = [];
    this._http.getUserFromName(this.userLogin.Name).subscribe(user_data => {
      console.log(user_data);
      if (!user_data.hasOwnProperty('password')) {
        this.userLogin = userAccount();
        this.messages = sendErrorMessages(user_data);
      } else {
        let result_task = this._http.comparePassword(this.userLogin.Password, user_data['password']);
        result_task.subscribe(data => {
          this.userLogin = userAccount();
          this.messages = [];
          if (data == true) {
            this._router.navigate(['account', user_data['userID']]);
          } else {
            this._router.navigate(['home']);
          }
        });
      }
    }, (error) => console.log(error), () => console.log('Complete'));
    this.flash = this.messages.length > 0;

  }


  uCreateAccount() {
    this.messages = [];
    console.log(this.userReg);
    if (this.userReg.Name.length == 0) {
      this.messages.push('Name shouldn\'t be empty!');
    } else if (this.userReg.Password.length == 0) {
      this.messages.push('Password shouldn\'t be empty!');
    } else {
      this._http.postUser(this.userReg.Name, this.userReg.Password).subscribe(data => {
        console.log(data);
        this._router.navigate(['home']);
      });

    }
    this.flash = this.messages.length > 0;
  }
}

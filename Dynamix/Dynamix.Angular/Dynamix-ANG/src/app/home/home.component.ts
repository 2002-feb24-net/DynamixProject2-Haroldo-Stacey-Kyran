import { Component, OnInit } from '@angular/core';
import {HttpService} from '../http.service';

function userAccount(){
  return{
    Name: '',
    Email: '',
    Password: ''
  }
}


@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {
  userLogin: any;
  userReg: any;
  messages: Array<string>;
  flash: boolean;

  constructor(
    private _http: HttpService
  ) { }

  ngOnInit(): void {
  }

  uLogin() {


  }

  uCreateAccount() {

  }


}

import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { env } from 'process';

@Injectable({
  providedIn: 'root'
})
export class HttpService {
  private headers: HttpHeaders;
  _url: string = 'http://localhost:44329';
  constructor(private _http: HttpClient) {
    this._url = env['APIUrl'];
    if(this._url == undefined){
        this._url = 'http://localhost:5000';
    }
    this.headers = new HttpHeaders({'Content-Type': 'application/json; charset=utf-8'});
  }

  getUserById(id: string){
    return this._http.get(`${this._url}/api/user/name/${id}`);
  }

  getUserByName(name: string){

  }

  postuser(){

  }

  checkPassword(){

  }

}

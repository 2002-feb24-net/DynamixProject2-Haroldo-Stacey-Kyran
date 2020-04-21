import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { env } from 'process';

@Injectable({
  providedIn: 'root'
})
export class HttpService {
  private headers: HttpHeaders;
  _url: string;
  constructor(private _http: HttpClient) {
    this._url = env['APIUrl'];
    if(this._url == undefined){
        this._url = 'http://localhost:5000';
    }

  }
  getUser(id: string) {
    return this._http.get(`${this._url}/api/users/${id}`);
  }
  getUserFromName(name: string) {
    return this._http.get(`${this._url}/api/users/name/${name}`);
  }
  postUser(name: string, password: string) {
    return this._http.post(`${this._url}/apis/user`,
      { Name: name, Password: password }
    );
  }
  comparePassword(password: string, hashed: string) {
    return this._http.post(`${this._url}/api/compare`,
      { Password: password, Hashed: hashed }
    );
  }
}

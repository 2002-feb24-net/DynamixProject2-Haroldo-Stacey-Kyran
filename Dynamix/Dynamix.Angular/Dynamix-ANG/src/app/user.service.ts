import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';

import { Observable, of } from 'rxjs';
import { catchError, map, tap } from 'rxjs/operators';

import { User } from './user';
import { env } from 'process';

@Injectable({
  providedIn: 'root'
})
export class UserService {

  private headers: HttpHeaders;
  _url: string;
  private usersUrl = 'api/users';


  constructor(private _http: HttpClient) {


  }
  getUsers(): Observable<any> {
    return this._http.get(this.usersUrl);
  }

  getUser(id: string) {
    return this._http.get(`${this._url}/api/users/${id}`);
  }
  getUserFromName(name: string) {
    return this._http.get(`${this._url}/api/users/name/${name}`);
  }
  postUser(name: string, password: string) {
    return this._http.post(`${this._url}/api/users`,
      { Name: name, Password: password }
    );
  }
}

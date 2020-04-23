import { Injectable } from '@angular/core';
import { User } from './user.model';
import {HttpClient} from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class UserService {

  formData : User;
  list: User[];
  readonly rootURL = "https://localhost:44329/api"

  constructor(private _http: HttpClient) { }

  refreshList(){
    this._http.get(this.rootURL+'/Users')
    .toPromise().then(res => this.list = res as User[]);
  }

  postUsers(formData: User){
    return this._http.post(this.rootURL+'/Users',formData);
  }

  putEmployee(formData : User){
    return this._http.put(this.rootURL+'/Users/'+formData.UserId,formData);

   }

   deleteEmployee(id : number){
    return this._http.delete(this.rootURL+'/Users/'+id);
   }

}

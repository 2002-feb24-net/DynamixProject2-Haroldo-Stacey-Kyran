import { Injectable } from '@angular/core';
import {HttpClient} from '@angular/common/http';
import {Review} from './review.model';

@Injectable({
  providedIn: 'root'
})
export class ReviewServiceService {
formData: Review;
list: Review[];
readonly rootURL = "https://localhost:44329/api"

  constructor(private _http: HttpClient) { }
  refreshList(){
    this._http.get(this.rootURL+'/Reviews')
    .toPromise().then(res => this.list = res as Review[]);
  }

  postUsers(formData: Review){
    return this._http.post(this.rootURL+'/Reviews',formData);
  }

  putEmployee(formData : Review){
    return this._http.put(this.rootURL+'/Reviews'+formData.CreatorID,formData);

   }

   deleteEmployee(id : number){
    return this._http.delete(this.rootURL+'/Reviews'+id);
   }
}

import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class CommentService {
  formData : Comment;
  list: Comment[];
  readonly rootURL = "https://dynamix.azurewebsites.net/api"

  constructor(private http: HttpClient) { }

  getComment() {
    return this.http.get<Comment[]>(`${this.rootURL}/Comments`)
      .toPromise();
  }
  getCommentById()
  {
   return this.http.get<Comment>(`${this.rootURL}api/Comment/` + this.formData.id).toPromise();
  }
  CreateUser(comment: Comment){
    return this.http.post<Comment>(`${this.rootURL}api/Comment`, comment)
      .toPromise();
  }
  getCommentUpdateById(id : number)
  {
   return this.http.get<Comment>(`${this.rootURL}api/Comment/${id}`)
   .toPromise();
  }
 UpdateUser(comment: Comment){
  return this.http.put<Comment>(`${this.rootURL}api/Comment/${comment.id}`, comment)
  .toPromise();
 }
  refreshList(){
   this.http.get<Comment>(`${this.rootURL}api/Comment`)
   .toPromise()
   .then(res => this.list = res as Comment);
 }

}



import { Component, OnInit } from '@angular/core';
import { ToastrService } from 'ngx-toastr';
import { CommentService } from '../shared/comment.service';
import { NgForm } from '@angular/forms';

@Component({
  selector: 'app-comment',
  templateUrl: './comment.component.html',
  styleUrls: ['./comment.component.css']
})
export class CommentComponent implements OnInit {



  constructor(
    public commentService: CommentService,
    private toastr: ToastrService) { }

  ngOnInit() {
    // this.resetForm();
  }

  // resetForm(form?: NgForm){
  //   if (form != null)
  //   form.resetForm();
  // this.commentService.formData = {
  //   // commentID: null,


  //   }
  // }

  // onSubmit(form: NgForm) {
  //   if (form.value.UserId == null)
  //   this.insertRecord(form);
  // else
  //   this.updateRecord(form);

  // }

  // insertRecord(form: NgForm){
  //   this.commentService.postUsers(form.value).subscribe(res => {
  //     this.toastr.success('Success!', 'Account Created');
  //     this.resetForm(form);
  //     this.commentService.refreshList();
  // });
  // }

  // updateRecord(form: NgForm) {
  //   this.commentService.putEmployee(form.value).subscribe(res => {
  //     this.toastr.info('Updated Successfully', 'EMP. Register');
  //     this.resetForm(form);
  //     this.commentService.refreshList();
  //   });
  // }

}

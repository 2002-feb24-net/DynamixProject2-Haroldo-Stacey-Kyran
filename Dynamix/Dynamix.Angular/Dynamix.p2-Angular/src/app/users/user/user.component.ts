import { Component, OnInit } from '@angular/core';
import { UserService } from 'src/app/shared/user.service';
import { NgForm } from '@angular/forms';
import { ToastrService } from 'ngx-toastr';
import { User } from 'src/app/shared/user.model';

@Component({
  selector: 'app-user',
  templateUrl: './user.component.html',
  styleUrls: ['./user.component.css']
})
export class UserComponent implements OnInit {
user: User;
emailPattern: "^[a-z0-9._%]"
  constructor(
    public service: UserService,
    private toastr: ToastrService) { }

  ngOnInit() {
    this.resetForm();
  }

  resetForm(form?: NgForm){
    if (form != null)
    form.resetForm();
  this.service.formData = {
    UserId: null,
    FullName: '',
    Email: '',
    Username: '',
    Password: ''
    }
  }

  onSubmit(form: NgForm) {
    if (form.value.EmployeeID == null)
    this.insertRecord(form);
  else
    this.updateRecord(form);

  }

  insertRecord(form: NgForm){
    this.service.postUsers(form.value).subscribe(res => {
      this.toastr.success('Success!', 'Account Created');
      this.resetForm(form);
      this.service.refreshList();
  });
  }

  updateRecord(form: NgForm) {
    this.service.putEmployee(form.value).subscribe(res => {
      this.toastr.info('Updated Successfully', 'EMP. Register');
      this.resetForm(form);
      this.service.refreshList();
    });
  }

}

import { Component, OnInit } from '@angular/core';
import { ToastrService } from 'ngx-toastr';
import {ReviewServiceService} from 'src/app/shared/review-service.service';
import {ReviewComponent} from 'src/app/reviews/review/review.component';
import { Review } from 'src/app/shared/review.model';


@Component({
  selector: 'app-review-list',
  templateUrl: './review-list.component.html',
  styleUrls: ['./review-list.component.css']
})
export class ReviewListComponent implements OnInit {


  constructor(
    public service: ReviewServiceService,
    private toastr: ToastrService
  ) { }

  ngOnInit() {
    this.service.refreshList();
  }

  populateForm(emp: Review) {
    this.service.formData = Object.assign({}, emp);
  }

  onDelete(id: number) {
    if (confirm('Are you sure to delete this record?')) {
      this.service.deleteEmployee(id).subscribe(res => {
        this.service.refreshList();
        this.toastr.warning('Deleted successfully', 'EMP. Register');
      });
    }
  }
}

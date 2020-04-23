import { Component, OnInit } from '@angular/core';
import { UploadImageService } from 'src/app/shared/upload-image.service';
import { Observable } from 'rxjs';




@Component({
  selector: 'app-upload',
  templateUrl: './upload.component.html',
  styleUrls: ['./upload.component.css'],
  providers: [UploadImageService]
})
export class UploadComponent implements OnInit {


constructor(
  private imageservice: UploadImageService
  ) { }




  ngOnInit(): void {
  }



}

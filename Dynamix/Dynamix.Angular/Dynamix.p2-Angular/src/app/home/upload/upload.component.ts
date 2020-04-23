import { Component, OnInit } from '@angular/core';
import { UploadImageService } from 'src/app/shared/upload-image.service';

@Component({
  selector: 'app-upload',
  templateUrl: './upload.component.html',
  styleUrls: ['./upload.component.css'],
  providers: [UploadImageService]
})
export class UploadComponent implements OnInit {
imageUrl: string = "https://www.pdxcityclub.org/wp-content/plugins/fundlycrm/assets/images/default-donation.jpg";
fileToUpload: File = null;
  constructor(private imageservice: UploadImageService) { }

  ngOnInit(): void {
  }

  handleFileInput(file: FileList){
    this.fileToUpload = file.item(0);


  var reader = new FileReader();
  reader.onload = (event: any) => {
    this.imageUrl = event.target.result;
    }
  reader.readAsDataURL(this.fileToUpload);
  }

  OnSubmit(Caption, image){
    this.imageservice.postFile(Caption.value, this.fileToUpload).subscribe(
      data => {
        console.log('done');
        Caption.value = null;
        image.value = null;
      }
    );
  }
}

import { Component, OnInit } from '@angular/core';
import { UploadImageService } from 'src/app/shared/upload-image.service';
import { HttpClient, HttpEventType } from '@angular/common/http';


@Component({
  selector: 'app-upload',
  templateUrl: './upload.component.html',
  styleUrls: ['./upload.component.css'],
  providers: [UploadImageService]
})
export class UploadComponent implements OnInit {
imageUrl: string = "https://www.pdxcityclub.org/wp-content/plugins/fundlycrm/assets/images/default-donation.jpg";
fileData: File = null;
previewUrl:any = null;
fileUploadProgress: string = null;
uploadedFilePath: string = null;


  constructor(private _http: HttpClient) { }

  ngOnInit(): void {
  }

  fileProgress(fileInput: any) {
    this.fileData = <File>fileInput.target.files[0];
    this.preview();
}

  preview() {
    // Show preview
    var mimeType = this.fileData.type;
    if (mimeType.match(/image\/*/) == null) {
      return;
    }

    var reader = new FileReader();
    reader.readAsDataURL(this.fileData);
    reader.onload = (_event) => {
      this.previewUrl = reader.result;
    }
}

onSubmit() {
  const formData = new FormData();
  formData.append('files', this.fileData);

  this.fileUploadProgress = '0%';

  this._http.post('https://us-central1-tutorial-e6ea7.cloudfunctions.net/fileUpload', formData, {
    reportProgress: true,
    observe: 'events'
  })
  .subscribe(events => {
    if(events.type === HttpEventType.UploadProgress) {
      this.fileUploadProgress = Math.round(events.loaded / events.total * 100) + '%';
      console.log(this.fileUploadProgress);
    } else if(events.type === HttpEventType.Response) {
      this.fileUploadProgress = '';
      console.log(events.body);
      alert('SUCCESS !!');
    }

  })

  }

}

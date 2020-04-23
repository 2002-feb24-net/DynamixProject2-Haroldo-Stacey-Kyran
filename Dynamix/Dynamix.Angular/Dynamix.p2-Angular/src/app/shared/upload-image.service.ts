import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class UploadImageService {

  constructor(private _http: HttpClient) { }
  postFile(caption: string, fileToUpload: File) {
    const endpoint = 'http://localhost:44329/api/Reviews';
    const formData: FormData = new FormData();
    formData.append('Image', fileToUpload, fileToUpload.name);
    formData.append('ImageCaption', caption);
    return this._http
      .post(endpoint, formData);

  }
}

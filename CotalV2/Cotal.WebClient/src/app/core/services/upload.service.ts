import { Injectable } from '@angular/core';
import { DataService } from "app/core/services/data.service";
import { UtilityService } from "app/core/services/utility.service";

@Injectable()
export class UploadService {
  public responseData: any;
  constructor(private dataService: DataService, private utilityService: UtilityService) { }
  postWithFile(url: string, postData: any, files: File[]) {
    let formData: FormData = new FormData();
    formData.append('files', files[0], files[0].name);

    if (postData !== "" && postData !== undefined && postData !== null) {
      for (var property in postData) {
        if (postData.hasOwnProperty(property)) {
          formData.append(property, postData[property]);
        }
      }
    }
    var returnReponse = new Promise((resolve, reject) => {
      this.dataService.postFile(url, formData).subscribe(
        res => {
          this.responseData = res.imageUrl_1; 
          resolve(this.responseData);
        },
        error => this.dataService.handleError(error)
      );
    });
    return returnReponse;
  }
}

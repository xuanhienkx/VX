import { Component, OnInit } from '@angular/core';
import { SystemConstants } from "../../core/common/system.constants";
import { DataService } from "../../core/services/data.service";

@Component({
  selector: 'app-home-new',
  templateUrl: './home-new.component.html',
  styleUrls: ['./home-new.component.css']
})
export class HomeNewComponent implements OnInit {


  public postLeft: any;
  public postTop: any[];
  public postRight: any[];
  public baseFolder: string = SystemConstants.BASE_API;
  public imageLeft :string;
  public nameLeft :string;
  public createdByLeft :string;
  public createdDateLeft : any;

  constructor(private _dataService: DataService) { }
  ngOnInit() {
    this.loadData();
  }
  loadData() {
    this._dataService.get('/api/Post/GetTop?top=3')
      .subscribe((response: any) => {
        this.postTop = response;
        this.postLeft = this.postTop[0];
        this.postRight = this.postTop.filter(p => p.Id != this.postLeft.Id);
        this.imageLeft = this.baseFolder + this.postLeft.Image;
        this.createdDateLeft =   this.postLeft.CreatedDate;
        this.createdByLeft =   this.postLeft.CreatedBy;
        this.nameLeft =   this.postLeft.Name; 
      }, error => this._dataService.handleError(error));
  }
   
} 

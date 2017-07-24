import { Component, OnInit, ViewChild } from '@angular/core';
import { ModalDirective } from "ngx-bootstrap";
import { SystemConstants } from "../../core/common/system.constants";
import { DataService } from "../../core/services/data.service";
import { NotificationService } from "../../core/services/notification.service";
import { UtilityService } from "../../core/services/utility.service";
import { UploadService } from "../../core/services/upload.service";
import { AuthenService } from "../../core/services/authen.service";
import { MessageContstants } from "../../core/common/message.constants";
import { NgForm } from "@angular/forms";

@Component({
  selector: 'app-slider',
  templateUrl: './slider.component.html',
  styleUrls: ['./slider.component.css']
})
export class SliderComponent implements OnInit {
  @ViewChild('modalAddEdit') public modalAddEdit: ModalDirective;
  @ViewChild('image') image;
  public pageIndex: number = 1;
  public pageSize: number = 20;
  public pageDisplay: number = 10;
  public totalRow: number;
  public sliders: any[];
  public entity: any;
  public filter: string = '';
  public baseFolder: string = SystemConstants.BASE_API;
  public slideTypes: any[]
  constructor(private _dataService: DataService,
    private _notificationService: NotificationService,
    private _utilityService: UtilityService, public _authenService: AuthenService,
    private _uploadService: UploadService) {

  }

  ngOnInit() {
    this.loadData();
  }
  loadData() {

    this._dataService.get('/api/Slider/GetAll?page=' + this.pageIndex + '&pageSize=' + this.pageSize + '&keyword=' + this.filter)
      .subscribe((response: any) => {
        this.sliders = response.Data; 
        this.pageIndex = response.PageNumber;
        this.totalRow = response.TotalEntityCount;
      }, error => this._dataService.handleError(error));
  }

  public keyupHandlerContentFunction(e: any) {
    this.entity.Content = e;
  }
  public reset() {
    this.filter = '';
    this.loadData();
  }
  public pageChanged(event: any): void {
    this.pageIndex = event.page;
    this.loadData();
  }
  loadSlideType() {
    this._dataService.getEnumAsList("SlideType").subscribe((response: any[]) => {
      this.slideTypes = response; 
    }, error => this._dataService.handleError(error));
  }
  //Show add form
  public showAdd() {
    this.entity = { Content: '' };
    this. loadSlideType();
    this.modalAddEdit.show();
  }
  //Show edit form
  public showEdit(id: string) {
    this. loadSlideType();
    this.entity = { Content: '' };
    this._dataService.get('/api/Slider/Detail/' + id).subscribe((response: any) => {
      this.entity = response;
      this.modalAddEdit.show();
    }, error => this._dataService.handleError(error));
  }
  public delete(id: string) {
    this._notificationService.printConfirmationDialog(MessageContstants.CONFIRM_DELETE_MSG, () => {
      this._dataService.delete('/api/Slider/Delete/', 'id', id).subscribe((response: any) => {
        this._notificationService.printSuccessMessage(MessageContstants.DELETED_OK_MSG);
        this.loadData();
      }, error => this._dataService.handleError(error));
    });
  }
  saveChange(form: NgForm) {
    if (form.valid) {
      let fi = this.image.nativeElement;
      if (fi.files.length > 0) {
        this._uploadService.postWithFile('/api/Upload/SaveImage?type=slider', null, fi.files)
          .then((imageUrl: string) => {
            this.entity.Image = imageUrl;
          }).then(() => {
            this.saveData(form);
          });
      }
      else {
        this.saveData(form);
      }
    }
  }

  private saveData(form: NgForm) {
    if (this.entity.Id == undefined) {
      this._dataService.post('/api/Slider/Add', JSON.stringify(this.entity))
        .subscribe((response: any) => {
          this.reset();
          this.modalAddEdit.hide();
          this._notificationService.printSuccessMessage(MessageContstants.CREATED_OK_MSG);
        }, error => this._dataService.handleError(error));
    }
    else {
      this._dataService.put('/api/Slider/Update', JSON.stringify(this.entity))
        .subscribe((response: any) => {
          this.reset();
          this.modalAddEdit.hide();
          this._notificationService.printSuccessMessage(MessageContstants.UPDATED_OK_MSG);
        }, error => this._dataService.handleError(error));
    }
  }
}

import { Component, OnInit, TemplateRef, ViewChild } from '@angular/core';
import { SystemConstants } from "../../core/common/system.constants";
import { DataService } from "../../core/services/data.service";
import { ModalDirective } from "ngx-bootstrap";

@Component({
  selector: 'app-home-service',
  templateUrl: './home-service.component.html',
  styleUrls: ['./home-service.component.css']
})
export class HomeServiceComponent implements OnInit {
  @ViewChild('detailShownModal') public detailShownModal: ModalDirective;
  public isModalShown: boolean = false;
  public services: any[];
  public entity: any = {};
  public baseFolder: string = SystemConstants.BASE_API;

  constructor(private _dataService: DataService) { }
  ngOnInit() {
    this.loadData();
  }
  loadData() {
    this._dataService.get('/api/OutService/GetAllClient')
      .subscribe((response: any) => {
        this.services = response;
      }, error => this._dataService.handleError(error));
  }
  public showModal(id: any): void {
    this.entity = this.services.filter(s => s.Id == id)[0];
    console.log(this.entity)
    this.detailShownModal.show();
  }

  public hideModal(): void {
    this.detailShownModal.hide();
  }
}

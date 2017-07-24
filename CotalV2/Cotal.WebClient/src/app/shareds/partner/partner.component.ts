import { Component, OnInit } from '@angular/core';
import { SystemConstants } from "../../core/common/system.constants";
import { DataService } from "../../core/services/data.service";

@Component({
  selector: 'app-partner',
  templateUrl: './partner.component.html',
  styleUrls: ['./partner.component.css']
})
export class PartnerComponent implements OnInit {

  public partners: any[];
  public baseFolder: string = SystemConstants.BASE_API;

  constructor(private _dataService: DataService) { }

  ngOnInit() {
    this.loadData(); 
  }
  loadData() {
    //GetAllActive
    this._dataService.get('/api/Slider/GetAllActive/Partner')
      .subscribe((response: any) => {
        this.partners = response; 
        console.log(this.partners)
      }, error => this._dataService.handleError(error));
  }
  prev() {
    let owl = $('#partners');
    owl.trigger('prev.owl.carousel');
  }
  next() {
    let owl = $('#partners');
    owl.trigger('next.owl.carousel');
  }


}

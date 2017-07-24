import { Component, OnInit } from '@angular/core';
import { SystemConstants } from "../../core/common/system.constants";
import { DataService } from "../../core/services/data.service";

@Component({
  selector: 'app-home-slider',
  templateUrl: './slider.component.html',
  styleUrls: ['./slider.component.css']
})
export class SliderComponent implements OnInit {

  public sliders: any[];
  public baseFolder: string = SystemConstants.BASE_API;

  constructor(private _dataService: DataService) { }
  ngOnInit() {
    this.loadData();
  }
  loadData() {
    //GetAllActive
    this._dataService.get('/api/Slider/GetAllActive/Main')
      .subscribe((response: any) => {
        this.sliders = response;
      }, error => this._dataService.handleError(error));
  }
  prev() {
    let owl = $('#owl-main-slider');
    owl.trigger('prev.owl.carousel');
  }
  next() {
    let owl = $('#owl-main-slider');
    owl.trigger('next.owl.carousel');
  }

}

import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { SliderRoutingModule } from './slider-routing.module';
import { SliderComponent } from './slider.component';
import { FormsModule } from "@angular/forms";
import { PaginationModule, ModalModule } from "ngx-bootstrap";
import { SimpleTinyModule } from "../../shared/simple-tiny/simple-tiny.module";
import { UploadService } from "../../core/services/upload.service";
import { DataService } from "../../core/services/data.service";
import { UtilityService } from "../../core/services/utility.service";

@NgModule({
  imports: [
    CommonModule,
    SliderRoutingModule,
    PaginationModule.forRoot(),
    FormsModule,
    ModalModule.forRoot(),
    SimpleTinyModule//.forRoot()
  ], providers: [DataService, UtilityService, UploadService],
  declarations: [SliderComponent]
})
export class SliderModule { }

import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { HomeRoutingModule } from './home-routing.module';
import { HomeComponent } from './home.component';
import { SliderComponent } from "./slider/slider.component";
import { HomeServiceComponent } from './home-service/home-service.component';
import { HomeNewComponent } from './home-new/home-new.component';
import { PartnerModule } from "../shareds/partner/partner.module";
import { UtilityService } from "../core/services/utility.service";
import { AuthenService } from "../core/services/authen.service";
import { DataService } from "../core/services/data.service";
import { NotificationService } from "../core/services/notification.service";
import { UploadService } from "../core/services/upload.service";
import { ModalModule } from 'ngx-bootstrap';

@NgModule({
  imports: [
    CommonModule,
    HomeRoutingModule,
    PartnerModule,
    ModalModule.forRoot() 
  ], 
  providers: [DataService,NotificationService],
  declarations: [HomeComponent,SliderComponent, HomeServiceComponent, HomeNewComponent]
})
export class HomeModule { }

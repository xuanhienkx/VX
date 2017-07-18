import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { HomeRoutingModule } from './home-routing.module';
import { HomeComponent } from './home.component';
import { SliderComponent } from "./slider/slider.component";
import { HomeServiceComponent } from './home-service/home-service.component';
import { HomeNewComponent } from './home-new/home-new.component';
import { PartnerModule } from "../shareds/partner/partner.module";

@NgModule({
  imports: [
    CommonModule,
    HomeRoutingModule,
    PartnerModule
    
  ],
  declarations: [HomeComponent,SliderComponent, HomeServiceComponent, HomeNewComponent]
})
export class HomeModule { }

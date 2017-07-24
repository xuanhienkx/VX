import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { ProviderRoutingModule } from './provider-routing.module';
import { ProviderComponent } from './provider.component';
import { DataService } from "../../core/services/data.service";
import { UtilityService } from "../../core/services/utility.service";
import { UploadService } from "../../core/services/upload.service";
import { PaginationModule, ModalModule } from "ngx-bootstrap";
import { FormsModule } from "@angular/forms";
import { SimpleTinyModule } from "../../shared/simple-tiny/simple-tiny.module";

@NgModule({
  imports: [
    CommonModule,
    ProviderRoutingModule,
    PaginationModule.forRoot(),
    FormsModule,
    ModalModule.forRoot(),
    SimpleTinyModule
  ], providers: [DataService, UtilityService, UploadService],
  declarations: [ProviderComponent]
})
export class ProviderModule { }

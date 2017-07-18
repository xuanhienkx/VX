import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { PartnerComponent } from './partner.component';

@NgModule({
  imports: [
    CommonModule
  ],
  declarations: [PartnerComponent], 
  exports:[PartnerComponent],
})
export class PartnerModule { }

import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { PageComponent } from './page.component';
import { Routes, RouterModule } from "@angular/router";
import { PaginationModule, ModalModule } from "ngx-bootstrap";
import { FormsModule } from "@angular/forms/"; 
import { UtilityService } from "../../core/services/utility.service";
import { UploadService } from "../../core/services/upload.service";  
import { SimpleTinyModule } from "../../shared/simple-tiny/simple-tiny.module";
import { DataService } from "../../core/services/data.service";
const routes: Routes = [
    { path: '', redirectTo: 'index', pathMatch: 'full' },
    { path: 'index', component: PageComponent }
];
@NgModule({
  imports: [
    CommonModule,
    RouterModule.forChild(routes),
    PaginationModule.forRoot(),
    FormsModule,
    ModalModule.forRoot(),
    SimpleTinyModule//.forRoot()
  ], providers: [DataService, UtilityService, UploadService],
  declarations: [PageComponent] 
})
export class PageModule { }

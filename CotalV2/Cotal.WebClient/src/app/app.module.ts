import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { HeaderComponent } from './shareds/header/header.component';
import { FooterComponent } from './shareds/footer/footer.component'; 
import { AuthGuard } from "./core/guards/auth.guard";
import { HttpModule } from "@angular/http"; 
import { FormsModule } from "@angular/forms";
import { AuthenService } from "./core/services/authen.service";
import { NotificationService } from "./core/services/notification.service";
import { UtilityService } from "./core/services/utility.service";

@NgModule({
  declarations: [
    AppComponent,
    HeaderComponent,
    FooterComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    FormsModule,
    HttpModule
  ],
  providers: [AuthGuard,AuthenService,UtilityService],
  bootstrap: [AppComponent]
})
export class AppModule { }

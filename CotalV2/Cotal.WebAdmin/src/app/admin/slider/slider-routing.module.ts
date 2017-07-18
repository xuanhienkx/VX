import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { SliderComponent } from "./slider.component";

const routes: Routes = [
   { path: '', redirectTo: 'index', pathMatch: 'full' },
    { path: 'index', component: SliderComponent }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class SliderRoutingModule { }

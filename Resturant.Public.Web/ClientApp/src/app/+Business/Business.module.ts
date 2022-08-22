import { NgModule } from "@angular/core";
import { BusinesRoutingModule } from "./Business-routing.module";
import { HomeComponent } from './Component/home/home.component';
import { NgImageSliderModule } from 'ng-image-slider';

@NgModule({
    declarations: [
    HomeComponent
  ],
  imports: [
    BusinesRoutingModule,
    NgImageSliderModule
  ]
})
export class BusinessModule {
}
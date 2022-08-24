import { NgModule } from "@angular/core";
import { BusinesRoutingModule } from "./Business-routing.module";
import { HomeComponent } from './Component/home/home.component';
import { FormsModule, ReactiveFormsModule } from "@angular/forms";
import { NgbModule } from "@ng-bootstrap/ng-bootstrap";

import { CommonModule } from "@angular/common";
import { AboutComponent } from './Component/about/about.component';
import { CommunityComponent } from './Component/community/community.component';

@NgModule({
    declarations: [
    HomeComponent,
    AboutComponent,
    CommunityComponent
  ],
  imports: [
    CommonModule,   
    BusinesRoutingModule,
    FormsModule,
    ReactiveFormsModule,
    NgbModule,

  ]
})
export class BusinessModule {
}
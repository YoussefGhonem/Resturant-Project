import { NgModule } from "@angular/core";
import { BusinesRoutingModule } from "./Business-routing.module";
import { HomeComponent } from './Component/home/home.component';
import { FormsModule, ReactiveFormsModule } from "@angular/forms";
import { NgbModule } from "@ng-bootstrap/ng-bootstrap";

import { CommonModule } from "@angular/common";
import { AboutComponent } from './Component/about/about.component';
import { CommunityComponent } from './Component/community/community.component';
import { MenuComponent } from './Component/menu/menu.component';
import { HappeningsComponent } from './Component/happenings/happenings.component';
import { ContactComponent } from './Component/contact/contact.component';
import { JopComponent } from './Component/jop/jop.component';
import { GalleryComponent } from './Component/gallery/gallery.component';
import { SharedComponentsModule } from "@shared/components/shared-components.module";

@NgModule({
    declarations: [
    HomeComponent,
    AboutComponent,
    CommunityComponent,
    MenuComponent,
    HappeningsComponent,
    ContactComponent,
    JopComponent,
    GalleryComponent
  ],
  imports: [
    CommonModule,   
    BusinesRoutingModule,
    FormsModule,
    ReactiveFormsModule,
    NgbModule,
    SharedComponentsModule,

  ]
})
export class BusinessModule {
}
import { NgModule, CUSTOM_ELEMENTS_SCHEMA } from '@angular/core';
// Component dashboard
import { defineLordIconElement } from 'lord-icon-element';

import { CommonModule } from "@angular/common";
import { WidgetModule } from "app/shared/widget/widget.module";
import { SharedModule } from "app/shared/shared.module";
import { FlatpickrModule } from "angularx-flatpickr";
import { SwiperModule } from "swiper/angular";
import { NgApexchartsModule } from "ng-apexcharts";
import { SimplebarAngularModule } from "simplebar-angular";
import { NgbDropdownModule, NgbNavModule, NgbToastModule } from "@ng-bootstrap/ng-bootstrap";
import { LeafletModule } from "@asymmetrik/ngx-leaflet";
import { CountToModule } from "angular-count-to";
import { FeatherModule } from "angular-feather";
import { allIcons } from "angular-feather/icons";
import { CrmComponent } from "app/+dashboard/components/crm/crm.component";
import { AnalyticsComponent } from "app/+dashboard/components/analytics/analytics.component";
import { ProjectsComponent } from './components/projects/projects.component';
import { NftComponent } from './components/nft/nft.component';
import { DashboardRoutingModule } from "app/+dashboard/dashboard-routing.module";
import { SwiperConfigInterface } from 'ngx-swiper-wrapper';
import { SWIPER_CONFIG } from 'ngx-swiper-wrapper';
import { DashboardComponent } from "app/+dashboard/components/dashboard/dashboard.component";
import { LightboxModule } from 'ngx-lightbox';
import { NgbProgressbarModule } from '@ng-bootstrap/ng-bootstrap';
import lottie from 'lottie-web';
import { CryptoComponent } from './components/crypto/crypto.component';
import { ToastsContainer } from "app/+dashboard/components/dashboard/toasts-container.component";

const DEFAULT_SWIPER_CONFIG: SwiperConfigInterface = {
  direction: 'horizontal',
  slidesPerView: 'auto'
};

@NgModule({
  declarations: [
    AnalyticsComponent,
    CrmComponent,
    CryptoComponent,
    ProjectsComponent,
    NftComponent,
    DashboardComponent,

  ],
  imports: [
    CommonModule,
    NgbToastModule,
    FeatherModule.pick(allIcons),
    CountToModule,
    LeafletModule,
    NgbDropdownModule,
    NgbNavModule,
    SimplebarAngularModule,
    NgApexchartsModule,
    SwiperModule,
    FlatpickrModule.forRoot(),
    SharedModule,
    WidgetModule,
    NgbProgressbarModule,
    LightboxModule,
    DashboardRoutingModule
  ],
  providers: [
    {
      provide: SWIPER_CONFIG,
      useValue: DEFAULT_SWIPER_CONFIG
    }
  ],
  schemas: [CUSTOM_ELEMENTS_SCHEMA]

})
export class DashboardModule {
  constructor() {
    defineLordIconElement(lottie.loadAnimation);
  }
}

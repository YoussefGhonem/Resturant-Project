// Template Modules
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { SettingsRoutingModule } from "./settings-routing.module";
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import {
  NgbAccordionModule,
  NgbActiveModal,
  NgbDropdownModule, NgbNavModule,
  NgbPaginationModule,
  NgbRatingModule, NgbTooltipModule,
  NgbTypeaheadModule
} from "@ng-bootstrap/ng-bootstrap";
import { NgxSliderModule } from "@angular-slider/ngx-slider";
import { SimplebarAngularModule } from "simplebar-angular";
import { SwiperModule } from "ngx-swiper-wrapper";
import { CKEditorModule } from "@ckeditor/ckeditor5-angular";
import { DropzoneModule } from "ngx-dropzone-wrapper";
import { FlatpickrModule } from "angularx-flatpickr";
import { NgSelectModule } from "@ng-select/ng-select";
import { CountToModule } from "angular-count-to";
import { SharedModule } from "app/shared/shared.module";
import { NgxMaskModule } from "ngx-mask";
import { SharedDirectivesModule } from "@shared/directives/shared-directives.module";
import { SharedComponentsModule } from '@shared/components/shared-components.module';
import { SharedPipesModule } from '@shared/pipes/pipes.module';
import { ApplicationSettingsComponent } from './components/application-settings/application-settings.component';
import { AboutUsComponent } from './components/application-settings/about-us/about-us.component';
import { PrivateDiningComponent } from './components/application-settings/private-dining/private-dining.component';
import { ReactiveValidationModule } from 'angular-reactive-validation';
import { GalleryComponent } from './components/application-settings/gallery/gallery.component';
import { LightboxModule } from 'ngx-lightbox';
import { AddGalleryComponent } from './components/application-settings/gallery/add-gallery/add-gallery.component';
import { PrivateDiningImagesComponent } from './components/application-settings/private-dining-images/private-dining-images.component';
import { AddPrivateDiningImagesComponent } from './components/application-settings/private-dining-images/add-private-dining-images/add-private-dining-images.component';
import { LocationsComponent } from './components/application-settings/locations/locations.component';
// Components

@NgModule({
  declarations: [
    ApplicationSettingsComponent,
    AboutUsComponent,
    PrivateDiningComponent,
    GalleryComponent,
    AddGalleryComponent,
    PrivateDiningImagesComponent,
    AddPrivateDiningImagesComponent,
    LocationsComponent
  ],
  imports: [
    SettingsRoutingModule,
    CommonModule,
    FormsModule,
    ReactiveFormsModule,
    NgbPaginationModule,
    NgbTypeaheadModule,
    NgbDropdownModule,
    NgbNavModule,
    NgbAccordionModule,
    NgbRatingModule,
    NgbTooltipModule,
    NgxSliderModule,
    SimplebarAngularModule,
    ReactiveValidationModule,
    SwiperModule,
    CKEditorModule,
    DropzoneModule,
    FlatpickrModule.forRoot(),
    NgSelectModule,
    CountToModule,
    SharedModule,
    NgxMaskModule.forRoot(),
    SharedDirectivesModule,
    SharedComponentsModule,
    SharedPipesModule,
    LightboxModule
  ],
  providers: [
    NgbActiveModal
  ],
})
export class SettingsModule {
}

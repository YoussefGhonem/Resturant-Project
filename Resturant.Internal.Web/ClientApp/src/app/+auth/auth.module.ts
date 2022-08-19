import { NgModule, CUSTOM_ELEMENTS_SCHEMA } from '@angular/core';
import { CommonModule } from '@angular/common';
import { AuthRoutingModule } from "app/+auth/auth-routing.module";
// Libs
import { NgbCarouselModule, NgbModule, NgbToastModule } from "@ng-bootstrap/ng-bootstrap";
import { NgxMaskModule } from "ngx-mask";
// @shared
import { SharedDirectivesModule } from "@shared/directives/shared-directives.module";
// Components
import { ReactiveFormsModule, FormsModule } from '@angular/forms';
import { LoginComponent } from "app/+auth/components/login/login.component";
import { ForgotPasswordComponent } from "app/+auth/components/forgot-password/forgot-password.component";
import { ResetPasswordComponent } from "app/+auth/components/reset-password/reset-password.component";
import { defineLordIconElement } from "lord-icon-element";
import lottie from "lottie-web";

//#region

import { Page401Component } from './errors/page401/page401.component';
import { Page402Component } from './errors/page402/page402.component';
import { Page404Component } from './errors/page404/page404.component';
import { Page500Component } from './errors/page500/page500.component';

//#endregion

@NgModule({
  declarations: [
    LoginComponent,
    ForgotPasswordComponent,
    ResetPasswordComponent,
    Page401Component,
    Page402Component,
    Page404Component,
    Page500Component
  ],
  imports: [
    CommonModule,
    AuthRoutingModule,
    NgbModule,
    NgbCarouselModule,
    NgbToastModule,
    SharedDirectivesModule,
    NgxMaskModule.forRoot(),
    ReactiveFormsModule,
    FormsModule,

  ],
  schemas: [CUSTOM_ELEMENTS_SCHEMA]

})
export class AuthModule {
  constructor() {
    defineLordIconElement(lottie.loadAnimation);
  }
}

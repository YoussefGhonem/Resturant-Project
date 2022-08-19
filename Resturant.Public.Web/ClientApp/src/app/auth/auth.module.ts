import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { LoginComponent } from './Components/login/login.component';
import { ResetPasswordComponent } from './Components/reset-password/reset-password.component';
import { ForgetPasswordComponent } from './Components/forget-password/forget-password.component';
import { Page401Component } from './Errors/page401/page401.component';
import { Page404Component } from './Errors/page404/page404.component';
import { Page402Component } from './Errors/page402/page402.component';
import { Page405Component } from './Errors/page405/page405.component';
import { AuthRoutingModule } from './auth-routing.module';
import { HttpClientModule } from "@angular/common/http";
import { ReactiveFormsModule } from '@angular/forms';



@NgModule({
  declarations: [
    LoginComponent,
    ResetPasswordComponent,
    ForgetPasswordComponent,
    Page401Component,
    Page404Component,
    Page402Component,
    Page405Component
  ],
  imports: [
    CommonModule,
    AuthRoutingModule,
    HttpClientModule,
    ReactiveFormsModule
  ]
})
export class AuthModule {
}

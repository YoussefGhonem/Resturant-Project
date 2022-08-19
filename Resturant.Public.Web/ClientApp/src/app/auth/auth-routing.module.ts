import { NgModule } from "@angular/core";
import { RouterModule, Routes } from "@angular/router";
import { ForgetPasswordComponent } from "./Components/forget-password/forget-password.component";
import { LoginComponent } from "./Components/login/login.component";
import { ResetPasswordComponent } from "./Components/reset-password/reset-password.component";

//#endregion

// Components

const routes: Routes = [
 
  {
    path: "Login",
    component: LoginComponent
  },
  {
    path:"ForgetPassword",
    component:ForgetPasswordComponent
  },
  {
    path:"ResetPassword",
    component:ResetPasswordComponent
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class AuthRoutingModule {

}

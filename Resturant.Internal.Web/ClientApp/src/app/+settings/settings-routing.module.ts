import { NgModule } from '@angular/core';
import { RouterModule, Routes } from "@angular/router";
import { ApplicationSettingsComponent } from './components/application-settings/application-settings.component';
import { PressComponent } from './components/press/press.component';

const routes: Routes = [
  {
    path: "",
    component: ApplicationSettingsComponent,
  },
  {
    path: "press-list",
    component: PressComponent,
  },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class SettingsRoutingModule {
}

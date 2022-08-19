import { NgModule } from '@angular/core';
import { RouterModule, Routes } from "@angular/router";
import { ApplicationSettingsComponent } from './components/application-settings/application-settings.component';

const routes: Routes = [
  {
    path: "",
    component: ApplicationSettingsComponent,
  },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class SettingsRoutingModule {
}

import { NgModule } from '@angular/core';
import { RouterModule, Routes } from "@angular/router";
import {AnalyticsComponent} from "app/+dashboard/components/analytics/analytics.component";
import {CrmComponent} from "app/+dashboard/components/crm/crm.component";
import {CryptoComponent} from "app/+dashboard/components/crypto/crypto.component";
import {ProjectsComponent} from "app/+dashboard/components/projects/projects.component";
import {NftComponent} from "app/+dashboard/components/nft/nft.component";

const routes: Routes = [
  {
    path: "",
    component: AnalyticsComponent
  },
  {
    path: "crm",
    component: CrmComponent
  },
  {
    path: "crypto",
    component: CryptoComponent
  },
  {
    path: "projects",
    component: ProjectsComponent
  },
  {
    path: "nft",
    component: NftComponent
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class DashboardRoutingModule {
}

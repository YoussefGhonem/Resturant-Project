import { NgModule } from "@angular/core";
import { RouterModule, Routes } from "@angular/router";
import { AboutComponent } from "./Component/about/about.component";
import { CommunityComponent } from "./Component/community/community.component";
import { HomeComponent } from "./Component/home/home.component";


//#endregion

// Components

const routes: Routes = [
  {
    path: "Home",
    component: HomeComponent
  },
  {
    path: "About",
    component: AboutComponent
  },
  {
    path: "Community",
    component: CommunityComponent
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class BusinesRoutingModule {

}

import { NgModule } from "@angular/core";
import { RouterModule, Routes } from "@angular/router";
import { HomeComponent } from "./Component/home/home.component";


//#endregion

// Components

const routes: Routes = [
  {
    path: "Home",
    component: HomeComponent
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class BusinesRoutingModule {

}

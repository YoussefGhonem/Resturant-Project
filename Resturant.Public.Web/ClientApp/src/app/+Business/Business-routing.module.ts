import { NgModule } from "@angular/core";
import { RouterModule, Routes } from "@angular/router";
import { AboutComponent } from "./Component/about/about.component";
import { CommunityComponent } from "./Component/community/community.component";
import { ContactComponent } from "./Component/contact/contact.component";
import { GalleryComponent } from "./Component/gallery/gallery.component";
import { HappeningsComponent } from "./Component/happenings/happenings.component";
import { HomeComponent } from "./Component/home/home.component";
import { JopComponent } from "./Component/jop/jop.component";
import { MenuComponent } from "./Component/menu/menu.component";


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
  },
  {
    path: "Menu",
    component: MenuComponent
  },
  {
    path: "Happenings",
    component: HappeningsComponent
  },
  {
    path: "Gallery",
    component: GalleryComponent
  },
  {
    path: "Jop",
    component: JopComponent
  },
  {
    path: "Contact",
    component: ContactComponent
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class BusinesRoutingModule {

}

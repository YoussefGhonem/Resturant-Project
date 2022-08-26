import { ContactsComponent } from './contacts/contacts.component';
import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { PressComponent } from './press/press.component';
import { PrivateDiningComponent } from './componenets/private-dining/private-dining.component';
import { MenuComponent } from './componenets/menu/menu.component';
import { CreateMenuComponent } from './componenets/menu/create-menu/create-menu.component';
import { HappeningsComponent } from './componenets/happenings/happenings.component';
import { JobsComponent } from './componenets/jobs/jobs.component';

const routes: Routes = [
  {
    path: "press",
    component: PressComponent,
  },
  {
    path: "contacts",
    component: ContactsComponent,
  },
  {
    path: "private-dining",
    component: PrivateDiningComponent,
  },
  {
    path: "manu",
    component: MenuComponent,
  },
  {
    path: "manu/create",
    component: CreateMenuComponent,
  },
  {
    path: "happenings",
    component: HappeningsComponent,
  },
  {
    path: "jobs",
    component: JobsComponent,
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class BusinessRoutingModule { }

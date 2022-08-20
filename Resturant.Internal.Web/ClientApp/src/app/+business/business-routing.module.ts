import { ContactsComponent } from './contacts/contacts.component';
import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { PressComponent } from './press/press.component';
import { PrivateDiningComponent } from './componenets/private-dining/private-dining.component';

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
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class BusinessRoutingModule { }

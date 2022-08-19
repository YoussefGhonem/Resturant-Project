import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { PressComponent } from './press/press.component';

const routes: Routes = [
  {
    path: "press",
    component: PressComponent,
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class BusinessRoutingModule { }

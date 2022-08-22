import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';


const routes: Routes = [
  { path: 'Auth', loadChildren: () => import('./auth/auth.module').then(m => m.AuthModule) },
  { path: 'Busnisse', loadChildren: () => import('./+Business/Business.module').then(m => m.BusinessModule) }

];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule {
}

import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';


const routes: Routes = [
  { path: 'Auth', loadChildren: () => import('./auth/auth.module').then(m => m.AuthModule) },
  { path: 'Busnisse', loadChildren: () => import('./+Business/Business.module').then(m => m.BusinessModule) },
  {
    path: '',
    redirectTo: '/Business/Home' //Error 404 - Page not found
  },
  {
    path: '**',
    redirectTo: '/Business/Home' //Error 404 - Page not found
  }

];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule {
}

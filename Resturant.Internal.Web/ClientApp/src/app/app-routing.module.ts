import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AuthGuard } from './+auth/helpers';
import { LayoutComponent } from './layouts/layout.component';


const routes: Routes = [
  { path: 'auth', loadChildren: () => import('./+auth/auth.module').then(m => m.AuthModule) },
  { path: 'dashboard', canActivate: [AuthGuard], component: LayoutComponent, loadChildren: () => import('./+dashboard/dashboard.module').then(m => m.DashboardModule) },
  { path: 'users', canActivate: [AuthGuard], component: LayoutComponent, loadChildren: () => import('./+users/users.module').then(m => m.UsersModule) },
  { path: 'settings', canActivate: [AuthGuard], component: LayoutComponent, loadChildren: () => import('./+settings/settings.module').then(m => m.SettingsModule) },
  {
    path: '',
    redirectTo: '/dashboard',
    pathMatch: 'full'
  },
  {
    path: '**',
    redirectTo: '/dashboard' //Error 404 - Page not found
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule {
}

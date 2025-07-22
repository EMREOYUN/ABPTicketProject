import { authGuard, permissionGuard } from '@abp/ng.core';
import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

const routes: Routes = [
  {
    path: '',
    pathMatch: 'full',
    loadChildren: () =>
      import('./home/home.module').then(m => m.HomeModule),
  },
  {
    path: 'account',
    loadChildren: () =>
      import('@abp/ng.account').then(m => m.AccountModule.forLazy()),
  },
  {
    path: 'identity',
    loadChildren: () =>
      import('@abp/ng.identity').then(m => m.IdentityModule.forLazy()),
  },
  {
    path: 'tenant-management',
    loadChildren: () =>
      import('@abp/ng.tenant-management').then(m => m.TenantManagementModule.forLazy()),
  },
  {
    path: 'setting-management',
    loadChildren: () =>
      import('@abp/ng.setting-management').then(m => m.SettingManagementModule.forLazy()),
  },
  {
    path: 'events',
    loadChildren: () =>
      import('./event/event.module').then(md => md.EventModule)
  },
  {
    path: 'sellerlist',
    loadChildren: () =>
      import('./sellerlist/sellerlist.module').then(md => md.SellerlistModule)
  },
  {
    path: 'purchasedtickets',
    loadChildren: () =>
      import('./purchasedtickets/purchasedtickets.module').then(md => md.PurchasedticketsModule)
  },
  {
    path: 'favorites',
    loadChildren: () =>
      import('./favorites/favorites.module').then(md => md.FavoritesModule)
  },
];

@NgModule({
  imports: [RouterModule.forRoot(routes, {})],
  exports: [RouterModule],
})
export class AppRoutingModule {}

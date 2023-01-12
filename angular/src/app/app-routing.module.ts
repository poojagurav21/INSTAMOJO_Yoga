import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AppliedCoursesComponent } from './applied-courses/applied-courses.component';


const routes: Routes = [
  {
    path: '',
    pathMatch: 'full',
    loadChildren: () => import('./home/home.module').then(m => m.HomeModule),
  },
  {
    path: 'account',
    loadChildren: () => import('@abp/ng.account').then(m => m.AccountModule.forLazy()),
  },
  {
    path: 'identity',
    loadChildren: () => import('@abp/ng.identity').then(m => m.IdentityModule.forLazy()),
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
    path:'AppliedCourses',component: AppliedCoursesComponent,
    },
    { path: 'payment', loadChildren: () => import('./payment/payment.module').then(m => m.PaymentModule) },
    { path: 'paypal', loadChildren: () => import('./paypal/paypal.module').then(m => m.PaypalModule) },
];

@NgModule({
  imports: [RouterModule.forRoot(routes, {})],
  exports: [RouterModule],
})
export class AppRoutingModule {}

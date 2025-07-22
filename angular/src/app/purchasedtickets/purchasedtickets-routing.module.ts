import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { PurchasedticketsComponent } from './purchasedtickets.component';

const routes: Routes = [{ path: '', component: PurchasedticketsComponent }];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class PurchasedticketsRoutingModule { }

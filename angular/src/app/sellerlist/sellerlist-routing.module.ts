import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { SellerlistComponent } from './sellerlist.component';

const routes: Routes = [{ path: '', component: SellerlistComponent }];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class SellerlistRoutingModule { }

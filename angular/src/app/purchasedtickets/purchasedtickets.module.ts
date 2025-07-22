import { NgModule } from '@angular/core';
import { SharedModule } from '../shared/shared.module';

import { PurchasedticketsRoutingModule } from './purchasedtickets-routing.module';
import { PurchasedticketsComponent } from './purchasedtickets.component';
import { NgbDatepickerModule } from '@ng-bootstrap/ng-bootstrap';


@NgModule({
  declarations: [
    PurchasedticketsComponent
  ],
  imports: [
    SharedModule,
    PurchasedticketsRoutingModule,
    NgbDatepickerModule
  ]
})
export class PurchasedticketsModule { }

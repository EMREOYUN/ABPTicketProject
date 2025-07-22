import { NgModule } from '@angular/core';
import { SharedModule } from '../shared/shared.module';

import { SellerlistRoutingModule } from './sellerlist-routing.module';
import { SellerlistComponent } from './sellerlist.component';
import { NgbDatepickerModule } from '@ng-bootstrap/ng-bootstrap';


@NgModule({
  declarations: [
    SellerlistComponent
  ],
  imports: [
    SharedModule,
    SellerlistRoutingModule,
    NgbDatepickerModule
  ]
})
export class SellerlistModule { }

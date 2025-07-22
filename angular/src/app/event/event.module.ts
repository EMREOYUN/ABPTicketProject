import { NgModule } from '@angular/core';
import { SharedModule } from '../shared/shared.module';

import { EventRoutingModule } from './event-routing.module';
import { EventComponent } from './event.component';
import { NgbDatepickerModule } from '@ng-bootstrap/ng-bootstrap';


@NgModule({
  declarations: [
    EventComponent
  ],
  imports: [
    SharedModule,
    EventRoutingModule,
    NgbDatepickerModule
  ]
})
export class EventModule { }

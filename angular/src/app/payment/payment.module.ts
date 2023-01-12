import { NgModule } from '@angular/core';
import { SharedModule } from '../shared/shared.module';

import { PaymentRoutingModule } from './payment-routing.module';
import { PaymentComponent } from './payment.component';
import { PaymentstatusComponent } from './paymentstatus/paymentstatus.component';


@NgModule({
  declarations: [
    PaymentComponent,
    PaymentstatusComponent
  ],
  imports: [
    SharedModule,
    PaymentRoutingModule
  ]
})
export class PaymentModule { 
  
}

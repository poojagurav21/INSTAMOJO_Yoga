import { NgModule } from '@angular/core';
import { SharedModule } from '../shared/shared.module';
import { PaypalRoutingModule } from './paypal-routing.module';
import { PaypalComponent } from './paypal.component';




@NgModule({
  declarations: [
    PaypalComponent,
    
  ],
  imports: [
    SharedModule,
    PaypalRoutingModule
  ]
})
export class PaypalModule { 
  
}

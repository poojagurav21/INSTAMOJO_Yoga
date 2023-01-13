import { Component, OnInit } from '@angular/core';

import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { ActivatedRoute } from '@angular/router';
import { isNullOrEmpty } from '@abp/ng.core';
import { CreatePaymentDTO, PaymentAppServicesService, PaymentDetailsDTO } from '@proxy/payments';

@Component({
  selector: 'app-payment',
  templateUrl: './payment.component.html',
  styleUrls: ['./payment.component.scss']
})
export class PaymentComponent implements OnInit {

  constructor(
     private paymentAppServicesService: PaymentAppServicesService,
     private fb: FormBuilder,
     private route: ActivatedRoute
  ) {
 
   }
   form: FormGroup;
   isModalOpen = false;
   gatewayurl="";
   payment_id=""
   transaction_id=""
   orderid=""
   //paymentRequestId="string"
   createpayment = {} as CreatePaymentDTO;
   paymentdetail={} as PaymentDetailsDTO;
  ngOnInit(): void {

    this.route.queryParams
      .subscribe(params => {
      //  console.log(params); // { orderby: "price" }
     this. paymentdetail.paymentID = params.payment_id;
     this. paymentdetail.paymentRequestID=params.payment_request_id;
     this. paymentdetail.paymentStatus=params.payment_status;
    /// this.paymentdetail.status=params.payment_status
     if( this.paymentdetail.paymentID.length!=0)
    {
   this.paymentAppServicesService.createPaymentDetailsByInput(this.paymentdetail).subscribe((response) => {
      
    });
     }
     
      }
    );

  }
 
  createnewpayment() {
    this.createpayment = {} as CreatePaymentDTO;
    this.buildForm();
    this.isModalOpen = true;
  }
  save()
  {
    
    this.paymentAppServicesService.create(this.form.value).subscribe(response => {
      this.gatewayurl=response;
      this.isModalOpen = false;
      this.form.reset();
      window.location.href=this.gatewayurl;
  });
  }
  buildForm() {
    this.form = this.fb.group({
      name: [this.createpayment.name || '', Validators.required],
      email: [this.createpayment.email || '', Validators.required],
      address: [this.createpayment.address || '', Validators.required],
      phone: [this.createpayment.phone || '', Validators.required],
      amount: [this.createpayment.amount || '', Validators.required],
      description: [this.createpayment.description || '', Validators.required],
    //  paymentRequestId:[this.createpayment.paymentRequest_id || '', Validators.required]
      
    });
  }

}

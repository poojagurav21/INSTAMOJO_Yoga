import { ListService, PagedResultDto } from '@abp/ng.core';
import { Component, HostListener, OnInit } from '@angular/core';
import { Router } from '@angular/router';

import { ScriptService } from './ScriptService';
import { HttpClient } from '@angular/common/http';

import { AppliedService } from '@proxy/applied-course';
import { AppliedCreateOrUpdateDto } from '@proxy/applied-courses';
import { MakePaymentService } from '@proxy/make-payments';
declare let Razorpay: any;
@Component({
  selector: 'app-applied-courses',
  templateUrl: './applied-courses.component.html',
  styleUrls: ['./applied-courses.component.scss'],
  providers: [ListService]
})
export class AppliedCoursesComponent implements OnInit {
  applied:AppliedCreateOrUpdateDto[]=[]
  
  razorpayOptions = {
    "key": "",
    "currency": "",
    "name": "",
    "description": "",
    "image": "",
    "order_id": "",
    "handler": (response) => {
     
    }
  }
  returnrespe: returnresponce = new returnresponce();
  constructor(private http: HttpClient, public readonly list: ListService,private appliedCourse:AppliedService, private razerpay: MakePaymentService, private RZPS: ScriptService, private route: Router) {
    RZPS.load('Razorpay')
    RZPS.loadCSS('MDB')
  }
  ngOnInit(): void {
     this.appliedCourse.getAll().subscribe((data: any) => {
       this.applied = data;
     
    })
  }

  message: any = "Not yet stared";
  paymentId = "";
  error = "";
  title = 'angular-razorpay-intergration';
  options = {
    "key": "rzp_test_cIXg6NZobtdLs6",
    "amount":"200",
    "currency":"INR",
    "name": "Yoga Institute",
    "order_id": "",
    "callback_url": "http://localhost:4200/payment",
    "handler": function (response: any) {
      var event = new CustomEvent("payment.success",
        {
          detail: response,
          bubbles: true,
          cancelable: true
        }
      );
      window.dispatchEvent(event);
    },
    "prefill": {
      "name": "",
      "email": "",
      "contact": ""
    },
    "notes": {
      "address": ""
    },
    "theme": {
      "color": "#3399cc"
    }
  };
  paynow(event: any) {
    this.paymentId = '';
    this.error = '';
    let amount = event.totalFee;
    let country = event.countryName
   console.log("hello")
    let curency;
    let finalamount;
    let ccode;
    // let data1 = this.http.get('https://restcountries.com/v3.1/name/' + country).subscribe(res1 => {
    //   let currname = res1;
    //   let cname = currname[0];
    //  // let currencycode = JSON.stringify(cname.currencies)
    //   ccode = currencycode.slice(2, 5);
    //   let data = this.http.get('https://api.fastforex.io/convert?from=INR&to=' + ccode + '&amount=' + amount + '&api_key=76dcb825f7-a55684f11a-rna6w6').subscribe(res => {
    //     curency = res;
    //     let money = curency.result;
    //     let finalamount = money[ccode];
        
    //     this.options.amount = (finalamount.toFixed(2) * 100).toString();
    //     this.options.prefill.name = event.name;
    //     this.options.prefill.email = event.email;
    //     this.options.prefill.contact = event.mobileNumber;
    //     if(ccode=="USD"||ccode=="SGD"||ccode=="AUD"||ccode=="CED"||ccode=="EUR"||ccode=="GBP"||ccode=="HKD"||ccode=="INR"||ccode=="MYR")
    //     {
    //       this.options.currency=ccode;
    //     }
    //     else
    //     {
    //       this.options.currency="USD";
    //     }
         var rzp1 = new Razorpay(this.options);
         //debugger
         rzp1.open();
        rzp1.on('payment.failed', function (response: any) {
          console.log(response.error.code);
          console.log(response.error.description);
          console.log(response.error.source);
          console.log(response.error.step);
          console.log(response.error.reason);
          console.log(response.error.metadata.order_id);
          console.log(response.error.metadata.payment_id);
        //   debugger
        //   if (typeof response.razorpay_payment_id == 'undefined' ||  response.razorpay_payment_id < 1) {
        //     alert("Payment Failed!!!!");
        //     console.log("failed");
        //     var  redirect_url = this.route.navigate['/payment'];
       
        //    } else {
        //     alert("Payment Successfull!!!!");
        //     console.log("success");
        //         redirect_url = this.route.navigate['/payment'];
              
        //    }
         
        //    location.href = redirect_url;
        });
    //   });
    // });
  }  
  
  
  @HostListener('window:payment.success', ['$event'])
  onPaymentSuccess(event: any): void {
    this.message = "Success Payment";
  }
}
export class returnresponce {
  razorpay_order_id: string
  razorpay_payment_id: string
  razorpay_signature: string
  paymentstatus: boolean = false
}



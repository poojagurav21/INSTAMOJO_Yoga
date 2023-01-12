import { Component, ElementRef, OnInit, ViewChild } from "@angular/core";

declare var paypal;  
@Component({  
  selector: 'app-paypal',  
  templateUrl: './paypal.component.html',  
  styleUrls: ['./paypal.component.scss']  
})  
export class PaypalComponent implements OnInit {  
  @ViewChild('paypal') paypalElement: ElementRef;  
  constructor() { }  
  planId: any;  
  subcripId: any;  
  basicAuth = 'AVKol3yBcBDTDmOW_X7ujaTATSVjDt5npYOgwcnQN23uFieBKTAP-jJuwO_CGW3hSu-WbyJzM9pAzoP_+ECO-4Z_d6dsjAYtGAuTzYoYJI-QKjy53o99tJ3cXPjFF1Pod2yNiNlVkb1S2GSH46xJj1eYckNPdM9zw';  //Pass your ClientId + scret key
  
  ngOnInit() {     
    const self = this;  
    this.planId = 'P-20D52460DL479523BLV56M5Y';  //Default Plan Id
    paypal.Buttons({  
      createSubscription: function (data, actions) {  
        return actions.subscription.create({  
          'plan_id': self.planId,  
        });  
      },  
      onApprove: function (data, actions) {  
        console.log(data);  
        alert('You have successfully created subscription ' + data.subscriptionID);  
        self.getSubcriptionDetails(data.subscriptionID);  
      },  
      onCancel: function (data) {  
        // Show a cancel page, or return to cart  
        console.log(data);  
      },  
      onError: function (err) {  
        // Show an error page here, when an error occurs  
        console.log(err);  
      }  
  
    }).render(this.paypalElement.nativeElement);  
  
  }  
  // ============Start Get Subcription Details Method============================  
  getSubcriptionDetails(subcriptionId) {  
    const xhttp = new XMLHttpRequest();  
    xhttp.onreadystatechange = function () {  
      if (this.readyState === 4 && this.status === 200) {  
        console.log(JSON.parse(this.responseText));  
        alert(JSON.stringify(this.responseText));  
      }  
    };  
    xhttp.open('GET', 'https://api.sandbox.paypal.com/v1/billing/subscriptions/' + subcriptionId, true);  
    xhttp.setRequestHeader('Authorization', this.basicAuth);  
  
    xhttp.send();  
  }  
  // ============END Get Subcription Details Method========================  
  
}
import type { CreatePaymentDTO, PaymentDetailsDTO } from './models';
import { RestService } from '@abp/ng.core';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root',
})
export class PaymentAppServicesService {
  apiName = 'Default';
  

  create = (input: CreatePaymentDTO) =>
    this.restService.request<any, string>({
      method: 'POST',
      responseType: 'text',
      url: '/api/app/payment-app-services',
      body: input,
    },
    { apiName: this.apiName });
  

  createPaymentDetailsByInput = (input: PaymentDetailsDTO) =>
    this.restService.request<any, string>({
      method: 'POST',
      responseType: 'text',
      url: '/api/app/payment-app-services/payment-details',
      body: input,
    },
    { apiName: this.apiName });

  constructor(private restService: RestService) {}
}

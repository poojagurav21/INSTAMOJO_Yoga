import { RestService } from '@abp/ng.core';
import { Injectable } from '@angular/core';
import type { OrderModel, Paymentdetails, ProgramDetailDto, RazorPayOptionsModel, RefundData, RefundReSopnce } from '../razorepay/models';

@Injectable({
  providedIn: 'root',
})
export class MakePaymentService {
  apiName = 'Default';
  

  allPayment = () =>
    this.restService.request<any, Paymentdetails>({
      method: 'POST',
      url: '/api/app/make-payment/all-payment',
    },
    { apiName: this.apiName });
  

  createOrderByOrder = (order: OrderModel) =>
    this.restService.request<any, string>({
      method: 'POST',
      responseType: 'text',
      url: '/api/app/make-payment/order',
      body: order,
    },
    { apiName: this.apiName });
  

  fullRefundByPaymentId = (paymentId: string) =>
    this.restService.request<any, RefundReSopnce>({
      method: 'POST',
      url: `/api/app/make-payment/full-refund/${paymentId}`,
    },
    { apiName: this.apiName });
  

  getPaymentByProgramDetailsDto = (programDetailsDto: ProgramDetailDto) =>
    this.restService.request<any, RazorPayOptionsModel>({
      method: 'GET',
      url: '/api/app/make-payment/payment',
      params: { totalFee: programDetailsDto.totalFee },
    },
    { apiName: this.apiName });
  

  partialRefundByPaymentIdAndRefundData = (paymentId: string, refundData: RefundData) =>
    this.restService.request<any, RefundReSopnce>({
      method: 'POST',
      url: `/api/app/make-payment/partial-refund/${paymentId}`,
      body: refundData,
    },
    { apiName: this.apiName });

  constructor(private restService: RestService) {}
}

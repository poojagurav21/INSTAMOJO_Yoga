
export interface CreatePaymentDTO {
  name: string;
  address: string;
  email: string;
  phone: string;
  amount: number;
  description: string;
  paymentRequest_id?: string;
}

export interface PaymentDetailsDTO {
  paymentID: string;
  paymentRequestID: string;
  currentPaymentStatus?: string;
  paymentStatus: number;
}

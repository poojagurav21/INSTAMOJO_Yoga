
export interface Items {
  entity?: string;
  id?: string;
  amount?: number;
  currency?: string;
  status?: string;
  order_id?: string;
  invoice_id?: string;
  international?: string;
  method?: string;
  amount_refunded?: number;
  refund_status?: string;
  captured?: boolean;
  description?: string;
  card_id?: string;
  bank?: string;
  wallet?: string;
  vpa?: string;
  email?: string;
  notes?: string;
  contact?: string;
  fee?: number;
  tax?: number;
  error_code?: string;
  error_description?: string;
  error_source?: string;
  error_step?: string;
  error_reason?: string;
  transaction_id?: string;
  acquirer_data: object;
  created_at?: number;
}

export interface OrderModel {
  orderAmount: number;
  name?: string;
  orderAmountInSubUnits: number;
  currency?: string;
  payment_Capture: number;
  notes: Record<string, string>;
}

export interface Paymentdetails {
  count: number;
  items: Items[];
}

export interface ProgramDetailDto {
  totalFee: number;
}

export interface RazorPayOptionsModel {
  key?: string;
  amountInSubUnits: number;
  currency?: string;
  name?: string;
  description?: string;
  imageLogUrl?: string;
  orderId?: string;
  profileName?: string;
  profileContact?: string;
  profileEmail?: string;
  notes: Record<string, string>;
}

export interface RefundData {
  amount: number;
  speed?: string;
  notes: Record<string, object>;
  receipt?: string;
}

export interface RefundReSopnce {
  id?: string;
  entity?: string;
  amount: number;
  receipt?: string;
  currency?: string;
  payment_id?: string;
  notes: Record<string, object>;
  receipts?: string;
  acquirer_data: object;
  created_at: number;
  batch_id?: string;
  status?: string;
  speed_processed?: string;
  speed_requested?: string;
}

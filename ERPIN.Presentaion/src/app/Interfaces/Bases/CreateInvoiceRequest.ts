import { CreateInvocieDetailsRequest } from './CreateInvocieDetailsRequest';

export interface CreateInvoiceRequest {
  id: number;
  code: number;
  note: string | null;
  storeId: number | null;
  createdAt: string;
  paid: number;
  net: number;
  discount: number;
  discountRatio: number;
  tax: number;
  remain: number;
  total: number;
  invoiceDetails: CreateInvocieDetailsRequest[];
}

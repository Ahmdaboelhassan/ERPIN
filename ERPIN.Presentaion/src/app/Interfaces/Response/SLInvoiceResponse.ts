import { InvoiceResponseBase } from '../Bases/InvoiceResponseBase';

export interface SLInvoiceResponse extends InvoiceResponseBase {
  customerId: number | null;
}

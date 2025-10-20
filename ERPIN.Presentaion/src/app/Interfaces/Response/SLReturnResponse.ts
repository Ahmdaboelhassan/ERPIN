import { InvoiceResponseBase } from '../Bases/InvoiceResponseBase';

export interface SLReturnResponse extends InvoiceResponseBase {
  customerId: number | null;
}

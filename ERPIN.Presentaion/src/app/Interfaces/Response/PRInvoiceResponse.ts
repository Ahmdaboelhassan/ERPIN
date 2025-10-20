import { InvoiceResponseBase } from '../Bases/InvoiceResponseBase';

export interface PRInvoiceResponse extends InvoiceResponseBase {
  vendorId: number | null;
}

import { InvoiceResponseBase } from '../Bases/InvoiceResponseBase';

export interface PRReturnResponse extends InvoiceResponseBase {
  vendorId: number | null;
}

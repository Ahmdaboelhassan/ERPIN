import { InvoiceDetailsResponseBase } from './InvoiceDetailsResponseBase';

export interface InvoiceResponseBase {
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
  invoiceDetails: InvoiceDetailsResponseBase[];
}

import { CreateInvoiceRequest } from '../Bases/CreateInvoiceRequest';

export interface CreateSLInvoice extends CreateInvoiceRequest {
  customerId: number | null;
}

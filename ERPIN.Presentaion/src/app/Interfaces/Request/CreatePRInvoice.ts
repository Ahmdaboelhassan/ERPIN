import { CreateInvoiceRequest } from '../Bases/CreateInvoiceRequest';

export interface CreatePRInvoice extends CreateInvoiceRequest {
  vendorId: number | null;
}

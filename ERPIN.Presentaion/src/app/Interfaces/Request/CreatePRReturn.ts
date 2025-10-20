import { CreateInvoiceRequest } from '../Bases/CreateInvoiceRequest';

export interface CreatePRReturn extends CreateInvoiceRequest {
  vendorId: number | null;
}

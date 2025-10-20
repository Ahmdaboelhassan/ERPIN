import { CreateInvoiceRequest } from '../Bases/CreateInvoiceRequest';

export interface CreateSLReturn extends CreateInvoiceRequest {
  customerId: number | null;
}

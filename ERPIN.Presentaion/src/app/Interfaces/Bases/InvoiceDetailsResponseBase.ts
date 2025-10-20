export interface InvoiceDetailsResponseBase {
  id: number;
  itemId: number;
  quantity: number;
  unitPrice: number;
  discountRation1: number;
  discountRation2: number;
  discountRation3: number;
  discountValue: number;
  totalPrice: number;
  description: string | null;
  invoiceId: number;
  itemName: string;
  itemNameEn: string;
}

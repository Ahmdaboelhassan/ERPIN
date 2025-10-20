export interface InvoiceItem {
  id: number;
  code: number;
  name: string;
  nameEn: string | null;
  barCode: string | null;
  description: string | null;
  uOM: string | null;
  purchasePrice: number | null;
  sellPrice: number | null;
}

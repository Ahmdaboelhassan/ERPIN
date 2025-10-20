import { BaseNamedEntity } from './BaseNamedEntity';

export interface Item extends BaseNamedEntity {
  barCode: string | null;
  description: string | null;
  uOM: string | null;
  purchasePrice: number | null;
  sellPrice: number | null;
  isActive: boolean;
}

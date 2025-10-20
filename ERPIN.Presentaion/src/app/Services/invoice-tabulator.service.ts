import { Injectable } from '@angular/core';
import { InvoiceItem } from '../Interfaces/Response/InvoiceItem';
import { BehaviorSubject, Subject } from 'rxjs';
import { InvoiceDetailsResponseBase } from '../Interfaces/Bases/InvoiceDetailsResponseBase';
import { TabulatorFull as Tabulator } from 'tabulator-tables';
import { TranslateService } from '@ngx-translate/core';

@Injectable({
  providedIn: 'root',
})
export class InvoiceTabulatorService {
  items$ = new BehaviorSubject<InvoiceItem[]>([]);
  invoiceDetails$ = new BehaviorSubject<InvoiceDetailsResponseBase[]>([]);
  invoiceTable$ = new BehaviorSubject<Tabulator>(null);
  invoiceTotalPrice$ = new Subject<number>();
  lang = 'ar';

  constructor(private translate: TranslateService) {
    this.lang = this.translate.getCurrentLang();
  }

  getLocalizedColumn(key) {
    const translations = {
      en: {
        barCode: 'Bar Code',
        item: 'Item',
        quantity: 'Quantity',
        unitPrice: 'Unit Price',
        discount1: 'Discount %1',
        discount2: 'Discount %2',
        discount3: 'Discount %3',
        discountValue: 'Discount Value',
        totalPrice: 'Total Price',
        description: 'Description',
      },
      ar: {
        barCode: 'الباركود',
        item: 'الصنف',
        quantity: 'الكمية',
        unitPrice: 'سعر الوحدة',
        discount1: 'خصم ٪1',
        discount2: 'خصم ٪2',
        discount3: 'خصم ٪3',
        discountValue: 'قيمة الخصم',
        totalPrice: 'السعر الإجمالي',
        description: 'الوصف',
      },
      fr: {
        barCode: 'Code Barres',
        item: 'Article',
        quantity: 'Quantité',
        unitPrice: 'Prix unitaire',
        discount1: 'Remise %1',
        discount2: 'Remise %2',
        discount3: 'Remise %3',
        discountValue: 'Valeur de remise',
        totalPrice: 'Prix total',
        description: 'Description',
      },
    };
    const t = translations[this.lang];
    return t[key];
  }

  // Tabualtor Row Helper Row
  CalculateRowTotalPrice(cell) {
    const row = cell.getRow();
    const rowData = row.getData();
    const qty = Number(rowData.quantity) || 0;
    const unitPrice = Number(rowData.unitPrice) || 0;
    const disc = Number(rowData.discountValue) || 0;
    const totalPrice = qty * unitPrice - disc;

    const discountCell = row.getCell('totalPrice');
    discountCell.setValue(totalPrice.toFixed(2), true);
  }

  calculateRowDiscountValue(cell) {
    const row = cell.getRow();
    const rowData = row.getData();
    const disc1R = Number(rowData.discountRation1) / 100 || 0;
    const disc2R = Number(rowData.discountRation2) / 100 || 0;
    const disc3R = Number(rowData.discountRation3) / 100 || 0;
    const qty = Number(rowData.quantity) || 0;
    const price = Number(rowData.unitPrice) || 0;

    const totalPrice = qty * price;
    const discValue =
      totalPrice * (1 - (1 - disc1R) * (1 - disc2R) * (1 - disc3R));

    const discountCell = row.getCell('discountValue');
    discountCell.setValue(discValue.toFixed(2), true);
  }

  pushInvoiceTotal(cell) {
    const tableData = cell.getTable().getData();

    var total = tableData.reduce((acc, rowData) => {
      const totalPrice = Number(rowData.totalPrice) || 0;

      return totalPrice + acc;
    }, 0);

    this.invoiceTotalPrice$.next(total);
  }
}

import { Component, ElementRef, Input, ViewChild } from '@angular/core';
import { TabulatorFull as Tabulator } from 'tabulator-tables';
import { InvoiceDetailsResponseBase } from '../../Interfaces/Bases/InvoiceDetailsResponseBase';
import { InvoiceItem } from '../../Interfaces/Response/InvoiceItem';
import { ItemsService } from '../../Services/items.service';
import { TabulatorListItem } from '../../Interfaces/Response/TabulatorListItem';
import { InvoiceTabulatorService } from '../../Services/invoice-tabulator.service';
import { TranslateService } from '@ngx-translate/core';

@Component({
  selector: 'app-invoice-details-component',
  imports: [],
  templateUrl: './invoice-details-component.component.html',
  styleUrl: './invoice-details-component.component.css',
})
export class InvoiceDetailsComponentComponent {
  @ViewChild('invoiceDetails') tableRef!: ElementRef;
  @Input() discountActive: boolean = true;
  @Input() isSales: boolean = true;
  invoiceDetailsTabulator!: Tabulator;
  itemOptions: TabulatorListItem[] = [];
  items: InvoiceItem[] = [];
  lang = 'ar';

  constructor(
    private tableService: InvoiceTabulatorService,
    private itemsService: ItemsService,
    private translateService: TranslateService
  ) {
    this.lang = this.translateService.getCurrentLang();

    this.tableService.invoiceDetails$.subscribe({
      next: (data) => {
        if (this.tableRef) {
          this.initInvoiceDetailsTabulator(data, this.items);
        }
      },
    });
    this.itemsService.GetItemsForInvoice().subscribe({
      next: (items) => {
        this.items = items;
      },
    });
  }

  initInvoiceDetailsTabulator(
    details: InvoiceDetailsResponseBase[],
    items: InvoiceItem[]
  ) {
    const itemOptions = items.map<TabulatorListItem>((item) => ({
      value: item.id,
      label: item.name,
    }));

    const data = details && details.length > 0 ? details : [{}];

    this.invoiceDetailsTabulator = new Tabulator(this.tableRef.nativeElement, {
      layout: 'fitColumns',
      columns: [
        {
          title: this.tableService.getLocalizedColumn('barCode'),
          field: 'barCode',
          editor: 'input',
          cellEdited: (cell) => this.UpdateItemRowData(cell, items, true),
        },
        {
          title: this.tableService.getLocalizedColumn('item'),
          field: 'itemId',
          editor: 'list',
          editorParams: {
            values: itemOptions,
            autocomplete: true,
            listOnEmpty: true,
            allowEmpty: false,
          },
          formatter: (cell) => {
            const item = itemOptions.find((i) => i.value === cell.getValue());
            if (item) {
              return item.label;
            }
            return '';
          },
          cellEdited: (cell) => this.UpdateItemRowData(cell, items),
        },
        {
          title: this.tableService.getLocalizedColumn('quantity'),
          field: 'quantity',
          editor: 'number',
          bottomCalc: 'sum',
          validator: ['min:1'],
          mutator: function (value, data) {
            return value || 1;
          },
          cellEdited: (cell) => this.tableService.CalculateRowTotalPrice(cell),
        },
        {
          title: this.tableService.getLocalizedColumn('unitPrice'),
          field: 'unitPrice',
          editor: 'number',
          formatter: 'money',
          bottomCalc: 'sum',
          formatterParams: { precision: 2 },
          mutator: function (value, data) {
            return value || 0;
          },
          cellEdited: (cell) => this.tableService.CalculateRowTotalPrice(cell),
        },
        {
          title: this.tableService.getLocalizedColumn('discount1'),
          field: 'discountRation1',
          editor: 'number',

          formatterParams: { precision: 2 },
          visible: this.discountActive,
          mutator: function (value, data) {
            return value || 0;
          },
          cellEdited: (cell) =>
            this.tableService.calculateRowDiscountValue(cell),
        },
        {
          title: this.tableService.getLocalizedColumn('discount2'),
          field: 'discountRation2',
          editor: 'number',
          visible: this.discountActive,
          formatterParams: { precision: 2 },
          mutator: function (value, data) {
            return value || 0;
          },
          cellEdited: (cell) =>
            this.tableService.calculateRowDiscountValue(cell),
        },
        {
          title: this.tableService.getLocalizedColumn('discount3'),
          field: 'discountRation3',
          editor: 'number',
          visible: this.discountActive,
          formatterParams: { precision: 2 },
          mutator: function (value, data) {
            return value || 0;
          },
          cellEdited: (cell) =>
            this.tableService.calculateRowDiscountValue(cell),
        },
        {
          title: this.tableService.getLocalizedColumn('discountValue'),
          field: 'discountValue',
          editor: 'number',
          formatter: 'money',
          bottomCalc: 'sum',
          formatterParams: { precision: 2 },
          mutator: function (value, data) {
            return value || 0;
          },
          cellEdited: (cell) => this.tableService.CalculateRowTotalPrice(cell),
        },
        {
          title: this.tableService.getLocalizedColumn('totalPrice'),
          field: 'totalPrice',
          bottomCalc: 'sum',
          bottomCalcFormatter: (cell) => cell.getValue()?.toFixed(2),
          formatterParams: { precision: 2 },
          mutator: function (value, data) {
            return value || 0;
          },
          cellEdited: (cell) => this.tableService.pushInvoiceTotal(cell),
        },
        {
          title: this.tableService.getLocalizedColumn('description'),
          field: 'description',
          editor: 'input',
        },
        {
          title: this.tableService.getLocalizedColumn('actions'),
          field: 'actions',
          hozAlign: 'center',
          formatter: () => {
            return `
            <button class="addRow bg-green-500 hover:bg-green-700 text-white px-3 font-bold py-1 rounded mr-1">+</button>
            <button class="removeRow bg-red-500 hover:bg-red-700 text-white px-3 py-1 font-bold rounded">−</button>
          `;
          },
          cellClick: (e, cell) => {
            const row = cell.getRow();

            if ((e.target as HTMLElement).classList.contains('addRow')) {
              const table = cell.getTable();
              table.addRow({}, false, row);
            }

            if ((e.target as HTMLElement).classList.contains('removeRow')) {
              row.delete();
            }
          },
          width: 120,
        },
      ],
      data: data,
      rowContextMenu: [
        {
          label:
            "<i class='fas fa-plus-circle text-green-600'></i> Add New Row",
          action: (e, row) => {
            row.getTable().addRow();
          },
        },
        {
          label:
            "<i class='fas fa-trash-alt text-red-600'></i> Delete Current Row",
          action: (e, row) => {
            row.delete();
            const table = row.getTable();
            if (table.getData().length === 0) table.addRow({});
          },
        },
        {
          label: "<i class='fas fa-trash text-red-600'></i> Delete All Rows",
          action: (e, row) => {
            const table = row.getTable();
            table.clearData();
            table.addRow();
          },
        },
      ],
    });

    this.tableService.invoiceTable$.next(this.invoiceDetailsTabulator);
  }

  UpdateItemRowData(cell, items, isBarCode = false) {
    const row = cell.getRow();
    const rowData = row.getData();
    const qty = rowData.quantity;
    const item = items.find(
      (i) => i.id === cell.getValue() || i.barCode === cell.getValue()
    );

    if (!item) {
      const barCode = row.getCell('barCode');
      barCode.setValue('');
      return;
    }

    let unitPrice = item.purchasePrice;
    let totalPrice = item.purchasePrice * qty;

    if (this.isSales) {
      unitPrice = item.sellPrice;
      totalPrice = item.sellPrice * qty;
    }

    row.update({
      barCode: item.barCode,
      itemId: item.id,
      discountRation1: 0,
      discountRation2: 0,
      discountRation3: 0,
      discountValue: 0,
      unitPrice: this.isSales ? item.sellPrice : item.purchasePrice,
      itemName: item.name,
      itemNameEn: item.nameEn,
    });

    // Trigger The Edit To Push Totals
    row.getCell('totalPrice').setValue(totalPrice, true);

    if (isBarCode) {
      cell
        .getTable()
        .addRow({}, false)
        .then((row) => {
          const barcodeCell = row.getCell('barCode');
          setTimeout(() => barcodeCell.edit(), 100);
        });
    }
  }
}

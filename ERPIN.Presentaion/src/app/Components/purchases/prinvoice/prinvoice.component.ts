import { Component, ElementRef, ViewChild } from '@angular/core';
import { DateRangeComponent } from '../../date-range/date-range.component';
import { TabulatorFull as Tabulator } from 'tabulator-tables';
import { Router, RouterLink } from '@angular/router';
import { TranslatePipe, TranslateService } from '@ngx-translate/core';
import Swal from 'sweetalert2';
import { Title } from '@angular/platform-browser';
import { PRInvoiceService } from '../../../Services/PRinvoice.service';
import { PRInvoiceResponse } from '../../../Interfaces/Response/PRInvoiceResponse';

@Component({
  selector: 'app-prinvoice',
  imports: [DateRangeComponent, TranslatePipe, RouterLink],
  templateUrl: './prinvoice.component.html',
  styleUrl: './prinvoice.component.css',
})
export class PRInvoiceComponent {
  @ViewChild('tableRef', { static: true }) tableRef!: ElementRef;
  table!: Tabulator;

  constructor(
    private invocieService: PRInvoiceService,
    private router: Router,
    private translate: TranslateService,
    private title: Title
  ) {
    this.title.setTitle(translate.instant('PRInvoice.List'));
  }

  GetAllInvoice(dates: any) {
    this.invocieService.GetAll(dates.from, dates.to).subscribe({
      next: (invoices) => this.initTabulator(invoices),
      error: () => Swal.fire(this.translate.instant('Error'), '', 'error'),
    });
  }

  initTabulator(invoices: PRInvoiceResponse[]) {
    this.table = new Tabulator(this.tableRef.nativeElement, {
      data: invoices,
      height: '100%',
      layout: 'fitColumns',
      pagination: false,
      paginationSize: 20,
      paginationSizeSelector: [10, 25, 50, 100, 150, 200],
      reactiveData: true,
      columns: [
        {
          title: this.translate.instant('Invoice.Code'),
          field: 'code',
          width: 150,
        },
        {
          title: this.translate.instant('Invoice.Date'),
          field: 'createdAt',
          formatter: (cell) => new Date(cell.getValue()).toLocaleString(),
        },
        {
          title: this.translate.instant('Invoice.Disc'),
          field: 'discount',
          hozAlign: 'right',
        },
        {
          title: this.translate.instant('Invoice.Paid'),
          field: 'paid',
          hozAlign: 'right',
        },
        {
          title: this.translate.instant('Invoice.Net'),
          field: 'net',
          hozAlign: 'right',
        },
        {
          title: this.translate.instant('Invoice.Remains'),
          field: 'remain',
          hozAlign: 'right',
        },
        {
          title: '',
          formatter: (cell) => {
            const id = cell.getRow().getData().id;
            return `<button class="btn-edit text-blue-600 hover:underline" data-id="${id}">
                      <i class="fa-solid fa-pen-to-square"></i> ${this.translate.instant(
                        'Edit'
                      )}
                    </button>`;
          },
          hozAlign: 'center',
          cellClick: (e, cell) => {
            const id = cell.getRow().getData().id;
            this.router.navigate(['/Purchase', 'Edit', id]);
          },
        },
      ],
      columnDefaults: {
        headerFilter: 'input',
        headerFilterFunc: 'like',
        headerHozAlign: 'center',
      },
    });
  }
}

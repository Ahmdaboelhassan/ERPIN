import { Component } from '@angular/core';
import { InvoiceDetailsComponentComponent } from '../../../invoice-details-component/invoice-details-component.component';
import {
  FormBuilder,
  FormGroup,
  ReactiveFormsModule,
  Validators,
} from '@angular/forms';
import { ActivatedRoute, Router, RouterLink } from '@angular/router';
import { TranslatePipe, TranslateService } from '@ngx-translate/core';
import { NgFor } from '@angular/common';
import { SelectListItem } from '../../../../Interfaces/Response/SelectListItem';
import { StoresService } from '../../../../Services/stores.service';
import { CustomersService } from '../../../../Services/customers.service';
import { Title } from '@angular/platform-browser';
import { HelperService } from '../../../../Services/helper.service';
import { InvoiceTabulatorService } from '../../../../Services/invoice-tabulator.service';
import { forkJoin } from 'rxjs';
import { SLReturnService } from '../../../../Services/slreturn.service';
import { SLReturnResponse } from '../../../../Interfaces/Response/SLReturnResponse';
import { CreateSLInvoice } from '../../../../Interfaces/Request/CreateSLInvoice';
import Swal from 'sweetalert2';
import { environment } from '../../../../../environments/environment';
import { TabulatorFull as Tabulator } from 'tabulator-tables';

@Component({
  selector: 'app-create-slreturn',
  imports: [
    InvoiceDetailsComponentComponent,
    ReactiveFormsModule,
    RouterLink,
    TranslatePipe,
    NgFor,
  ],
  templateUrl: './create-slreturn.component.html',
  styleUrl: './create-slreturn.component.css',
})
export class CreateSlreturnComponent {
  invoiceTable!: Tabulator;
  invoiceForm!: FormGroup;
  stores: SelectListItem[] = [];
  customers: SelectListItem[] = [];
  itemsTotalsPrice: Number = 0;
  isEdit = false;

  constructor(
    private invoiceService: SLReturnService,
    private storeService: StoresService,
    private customerService: CustomersService,
    private titleService: Title,
    private route: ActivatedRoute,
    private router: Router,
    private fb: FormBuilder,
    private translate: TranslateService,
    private helperService: HelperService,
    private tableService: InvoiceTabulatorService
  ) {}

  ngOnInit(): void {
    forkJoin([
      this.storeService.GetAllSelectList(),
      this.customerService.GetAllSelectList(),
    ]).subscribe(([stores, customers]) => {
      this.stores = stores;
      this.customers = customers;

      this.route.params.subscribe((params) => {
        if (params['id']) {
          this.isEdit = true;
          this.titleService.setTitle(this.translate.instant('SLReturn.Edit'));
          this.getInvoice(+params['id']);
        } else {
          this.isEdit = false;
          this.titleService.setTitle(this.translate.instant('SLReturn.Create'));
          this.getInvoice();
        }
      });
    });

    this.tableService.invoiceTable$.subscribe({
      next: (table) => (this.invoiceTable = table),
    });
  }

  getInvoice(id?: number) {
    if (id) {
      this.invoiceService.getInvoice(id).subscribe((invoice) => {
        this.initInvoiceForm(invoice.data);
        this.tableService.invoiceDetails$.next(invoice.data.invoiceDetails);
      });
    } else {
      this.invoiceService.newInvoice().subscribe((invoice) => {
        this.initInvoiceForm(invoice.data);
        this.tableService.invoiceDetails$.next(invoice.data.invoiceDetails);
      });
    }
  }

  initInvoiceForm(invoice: SLReturnResponse) {
    this.invoiceForm = this.fb.group({
      id: [invoice.id],
      code: [invoice.code],
      note: [invoice.note],
      storeId: [invoice.storeId, Validators.required],
      storeName: [{ value: invoice.storeId, disabled: true }],
      customerId: [invoice.customerId, Validators.required],
      customerName: [{ value: invoice.customerId, disabled: true }],
      createdAt: [this.helperService.GetLocaleDateTime(invoice.createdAt)],
      paid: [invoice.paid, Validators.required],
      net: [invoice.net],
      discount: [invoice.discount],
      discountRatio: [invoice.discountRatio],
      tax: [invoice.tax],
      remain: [invoice.remain],
      total: [invoice.total],
    });

    this.tableService.invoiceTotalPrice$.subscribe({
      next: (totalPrice) => {
        this.itemsTotalsPrice = totalPrice;
        this.helperService.CalculateNetPrice(this.invoiceForm, totalPrice);
      },
    });
  }

  Submit() {
    const formValue = this.invoiceForm.value;

    const createModel: CreateSLInvoice = {
      id: formValue.id,
      code: formValue.code,
      note: formValue.note,
      storeId: formValue.storeId,
      customerId: formValue.customerId,
      createdAt: formValue.createdAt,
      paid: formValue.paid,
      net: formValue.net,
      discount: formValue.discount,
      discountRatio: formValue.discountRatio,
      tax: formValue.tax,
      remain: formValue.remain,
      total: formValue.total,
      invoiceDetails: this.invoiceTable.getData().filter((a) => a.itemId),
    };

    const apiCall = this.isEdit
      ? this.invoiceService.editInvoice(createModel)
      : this.invoiceService.createInvoice(createModel);

    apiCall.subscribe({
      next: (response) => {
        Swal.fire({
          title: this.titleService.getTitle(),
          text: response.message,
          icon: 'success',
          showConfirmButton: false,
          timer: environment.sweetAlertTimeOut,
        }).then(() => {
          if (this.isEdit) {
            this.printInvoice();
            window.location.reload();
          } else {
            this.router.navigate(['/SalesReturn', 'Edit', response.data]);
            this.printInvoice();
          }
        });
      },
      error: (error) => {
        Swal.fire({
          title: this.titleService.getTitle(),
          text: error.error.message,
          icon: 'error',
          showConfirmButton: true,
        });
      },
    });
  }

  Delete() {
    Swal.fire({
      title: this.translate.instant('areusure'),
      icon: 'warning',
      showCancelButton: true,
      confirmButtonText: this.translate.instant('Delete'),
      cancelButtonText: this.translate.instant('Cancel'),
    }).then((result) => {
      if (result.isConfirmed) {
        const id = this.invoiceForm.get('id')?.value;
        this.invoiceService.deleteInvoice(id).subscribe({
          next: (response) => {
            Swal.fire({
              title: this.translate.instant('Success'),
              text: response.message,
              icon: 'success',
              showConfirmButton: false,
              timer: environment.sweetAlertTimeOut,
            }).then(() => {
              this.router.navigate(['/SalesReturn', 'List']);
            });
          },
          error: (error) => {
            Swal.fire({
              title: this.translate.instant('Error'),
              text: error.error.message,
              icon: 'error',
              showConfirmButton: true,
            });
          },
        });
      }
    });
  }

  // Calculation Methods
  CalculateNetPrice() {
    this.helperService.CalculateNetPrice(
      this.invoiceForm,
      this.itemsTotalsPrice
    );
  }
  CalRemainValue() {
    this.helperService.CalRemainValue(this.invoiceForm);
  }

  CalcInvoiceDiscValue() {
    this.helperService.CalcInvoiceDiscValue(
      this.invoiceForm,
      this.itemsTotalsPrice
    );
  }

  CalcInvoiceDiscRatio() {
    this.helperService.CalcInvoiceDiscRatio(
      this.invoiceForm,
      this.itemsTotalsPrice
    );
  }

  printInvoice() {
    this.helperService.printInvoice({
      formData: this.invoiceForm.value,
      tableData: this.invoiceTable.getData().filter((a) => a.itemId),
      title: 'Invoice.Name',
    });
  }
}

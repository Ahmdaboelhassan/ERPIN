import { Injectable } from '@angular/core';
import { TranslateService } from '@ngx-translate/core';

@Injectable({
  providedIn: 'root',
})
export class HelperService {
  constructor(private translate: TranslateService) {}

  GetLocaleDateTime(dateString) {
    const date = new Date(dateString);
    const year = date.getFullYear();
    const month = String(date.getMonth() + 1).padStart(2, '0');
    const day = String(date.getDate()).padStart(2, '0');
    const hours = String(date.getHours()).padStart(2, '0');
    const minutes = String(date.getMinutes()).padStart(2, '0');
    return `${year}-${month}-${day}T${hours}:${minutes}`;
  }

  CalculateNetPrice(invoiceForm, total) {
    const formValue = invoiceForm.value;
    const discValue = formValue.discount;
    const tax = formValue.tax;
    const net = total - discValue + tax;
    const paid = net;
    const remain = net - paid;

    invoiceForm.patchValue({
      remain: remain,
      net: net,
      paid: paid,
    });
  }

  CalcInvoiceDiscValue(invoiceForm, total) {
    const formValue = invoiceForm.value;
    const ratio = formValue.discountRatio / 100;
    const discValue = (total * ratio).toFixed();
    invoiceForm.patchValue({ discount: discValue });
    this.CalculateNetPrice(invoiceForm, total);
  }

  CalcInvoiceDiscRatio(invoiceForm, total) {
    const formValue = invoiceForm.value;
    const value = formValue.discount;
    const ratio = ((value / total) * 100).toFixed(2);
    invoiceForm.patchValue({ discountRatio: ratio });
    this.CalculateNetPrice(invoiceForm, total);
  }

  CalRemainValue(invoiceForm) {
    const formValue = invoiceForm.value;
    const paid = formValue.paid;
    const net = formValue.net;
    const remain = (net - paid).toFixed(2);
    invoiceForm.patchValue({ remain: remain });
  }
  // Add this method to your component class
  printInvoice(data: any) {
    const { formData, tableData, title, items } = data;
    const total = tableData.reduce(
      (acc, row) => acc + Number(row.totalPrice),
      0
    );
    const isAR = this.translate.getCurrentLang() === 'ar';

    // ✅ Build HTML content
    const printContent = `
    <html>
      <head>
        <title>${this.translate.instant(title)} (${formData.code})</title>
        <style>
          body { font-family: Arial, sans-serif; margin: 20px; direction: ${
            isAR ? 'rtl' : 'ltr'
          }; }
          .invoice-header { text-align: center; margin-bottom: 20px; }
          .invoice-table { width: 100%; border-collapse: collapse; margin-top: 20px; }
          .invoice-table th, .invoice-table td { border: 1px solid #ddd; padding: 8px; }
          .invoice-table th { background-color: #f5f5f5; }
          .totals { margin-top: 20px; text-align: right; display: flex; flex-wrap: wrap; }
          .totals p { width: 50%; margin: 0; padding: 4px 0; }
        </style>
      </head>
      <body>
        <div class="invoice-header">
          <h1>${this.translate.instant(title)}</h1>
          <div style="display:flex;justify-content:space-between">
            <p>${formData.code.toString().padStart(10, '0')}</p>
            <p>${new Date(formData.createdAt).toLocaleString(
              isAR ? 'ar' : 'en'
            )} </p>
          </div>
        </div>

        <table class="invoice-table">
          <thead>
            <tr>
              <th>#</th>
              <th style="width:40%">${this.translate.instant('Item')}</th>
              <th>${this.translate.instant('Qty')}</th>
              <th>${this.translate.instant('Price')}</th>
              <th>${this.translate.instant('Total')}</th>
            </tr>
          </thead>
          <tbody>
            ${tableData
              .map((tItem: any, index: number) => {
                const itemName = isAR ? tItem.itemName : tItem.itemNameEn;
                return `
                  <tr>
                    <td>${index + 1}</td>
                    <td>${itemName || ''}</td>
                    <td>${tItem.quantity}</td>
                    <td>${tItem.unitPrice}</td>
                    <td>${tItem.totalPrice}</td>
                  </tr>
                `;
              })
              .join('')}
          </tbody>
        </table>

        <div class="totals">
          <p>${this.translate.instant('Invoice.Total')}: ${total}</p>
          <p>${this.translate.instant('Invoice.Net')}: ${formData.net}</p>
          <p>${this.translate.instant('Invoice.Disc')}: ${formData.discount}</p>
          <p>${this.translate.instant('Invoice.Paid')}: ${formData.paid}</p>
          <p>${this.translate.instant('Invoice.Tax')}: ${formData.tax}</p>
          <p>${this.translate.instant('Invoice.Remains')}: ${
      formData.remain
    }</p>
        </div>
        <script>
        window.onload = function() {
            setTimeout(() => {
              window.focus();
              window.print();
            }, 500);
          };
       </script>
      </body>
    </html>
  `;

    const printWindow = window.open('', '_blank', 'width=900,height=700');
    if (!printWindow) {
      alert('Please allow pop-ups for this site to print the invoice.');
      return;
    }

    printWindow.document.open();
    printWindow.document.write(printContent);
    printWindow.document.close();

    printWindow.onafterprint = () => {
      printWindow.close();
    };
  }
}

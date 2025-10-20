import { Injectable } from '@angular/core';
import { environment } from '../../environments/environment';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { SelectListItem } from '../Interfaces/Response/SelectListItem';
import { InvoiceItem } from '../Interfaces/Response/InvoiceItem';

@Injectable({
  providedIn: 'root',
})
export class ItemsService {
  baseUrl = environment.baseUrl + 'Items/';

  constructor(private httpClient: HttpClient) {}

  GetAllSelectList(): Observable<SelectListItem[]> {
    const url = this.baseUrl + 'GetAllSelectList';
    return this.httpClient.get<SelectListItem[]>(url);
  }
  GetItemsForInvoice(): Observable<InvoiceItem[]> {
    const url = this.baseUrl + 'GetItemsForInvoice';
    return this.httpClient.get<InvoiceItem[]>(url);
  }
}

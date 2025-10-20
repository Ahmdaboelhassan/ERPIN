import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { Observable } from 'rxjs';

import { PRInvoiceResponse } from '../Interfaces/Response/PRInvoiceResponse';
import { Result } from '../Interfaces/Response/Result';
import { environment } from '../../environments/environment';
import { CreatePRInvoice } from '../Interfaces/Request/CreatePRInvoice';

@Injectable({
  providedIn: 'root',
})
export class PRInvoiceService {
  private readonly baseUrl = environment.baseUrl + 'PRInvoice';

  constructor(private http: HttpClient) {}

  /** Get a new blank invoice with default values */
  newInvoice(): Observable<Result<PRInvoiceResponse>> {
    return this.http.get<Result<PRInvoiceResponse>>(`${this.baseUrl}/New`);
  }

  /** Get invoice by ID */
  getInvoice(id: number): Observable<Result<PRInvoiceResponse>> {
    return this.http.get<Result<PRInvoiceResponse>>(
      `${this.baseUrl}/Get/${id}`
    );
  }

  /** Create a new invoice */
  createInvoice(model: CreatePRInvoice): Observable<Result<number>> {
    return this.http.post<Result<number>>(`${this.baseUrl}/Create`, model);
  }

  /** Edit existing invoice */
  editInvoice(model: CreatePRInvoice): Observable<Result<number>> {
    return this.http.put<Result<number>>(`${this.baseUrl}/Edit`, model);
  }

  /** Delete invoice by ID */
  deleteInvoice(id: number): Observable<Result<number>> {
    return this.http.delete<Result<number>>(`${this.baseUrl}/Delete/${id}`);
  }
  GetAll(from, to): Observable<PRInvoiceResponse[]> {
    const params = new HttpParams().set('from', from).set('to', to);

    return this.http.get<PRInvoiceResponse[]>(`${this.baseUrl}/GetAll`, {
      params,
    });
  }
}

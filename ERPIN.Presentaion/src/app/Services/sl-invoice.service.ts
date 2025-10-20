import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { Observable } from 'rxjs';

import { SLInvoiceResponse } from '../Interfaces/Response/SLInvoiceResponse';
import { Result } from '../Interfaces/Response/Result';
import { CreateSLInvoice } from '../Interfaces/Request/CreateSLInvoice';
import { environment } from '../../environments/environment';

@Injectable({
  providedIn: 'root',
})
export class SlInvoiceService {
  private readonly baseUrl = environment.baseUrl + 'SLInvoice';

  constructor(private http: HttpClient) {}

  /** Get a new blank invoice with default values */
  newInvoice(): Observable<Result<SLInvoiceResponse>> {
    return this.http.get<Result<SLInvoiceResponse>>(`${this.baseUrl}/New`);
  }

  /** Get invoice by ID */
  getInvoice(id: number): Observable<Result<SLInvoiceResponse>> {
    return this.http.get<Result<SLInvoiceResponse>>(
      `${this.baseUrl}/Get/${id}`
    );
  }

  /** Create a new invoice */
  createInvoice(model: CreateSLInvoice): Observable<Result<number>> {
    return this.http.post<Result<number>>(`${this.baseUrl}/Create`, model);
  }

  /** Edit existing invoice */
  editInvoice(model: CreateSLInvoice): Observable<Result<number>> {
    return this.http.put<Result<number>>(`${this.baseUrl}/Edit`, model);
  }

  /** Delete invoice by ID */
  deleteInvoice(id: number): Observable<Result<number>> {
    return this.http.delete<Result<number>>(`${this.baseUrl}/Delete/${id}`);
  }
  GetAll(from, to): Observable<SLInvoiceResponse[]> {
    const params = new HttpParams().set('from', from).set('to', to);

    return this.http.get<SLInvoiceResponse[]>(`${this.baseUrl}/GetAll`, {
      params,
    });
  }
}

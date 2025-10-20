import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from '../../environments/environment';
import { SLReturnResponse } from '../Interfaces/Response/SLReturnResponse';
import { Result } from '../Interfaces/Response/Result';
import { Observable } from 'rxjs';
import { CreateSLInvoice } from '../Interfaces/Request/CreateSLInvoice';

@Injectable({
  providedIn: 'root',
})
export class SLReturnService {
  private readonly baseUrl = environment.baseUrl + 'SLReturn';

  constructor(private http: HttpClient) {}

  /** Get a new blank invoice with default values */
  newInvoice(): Observable<Result<SLReturnResponse>> {
    return this.http.get<Result<SLReturnResponse>>(`${this.baseUrl}/New`);
  }

  /** Get invoice by ID */
  getInvoice(id: number): Observable<Result<SLReturnResponse>> {
    return this.http.get<Result<SLReturnResponse>>(`${this.baseUrl}/Get/${id}`);
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
  GetAll(from, to): Observable<SLReturnResponse[]> {
    const params = new HttpParams().set('from', from).set('to', to);

    return this.http.get<SLReturnResponse[]>(`${this.baseUrl}/GetAll`, {
      params,
    });
  }
}

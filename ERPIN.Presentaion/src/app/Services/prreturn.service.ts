import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from '../../environments/environment';
import { PRReturnResponse } from '../Interfaces/Response/PRReturnResponse';
import { Result } from '../Interfaces/Response/Result';
import { Observable } from 'rxjs';
import { CreateSLInvoice } from '../Interfaces/Request/CreateSLInvoice';
import { CreatePRReturn } from '../Interfaces/Request/CreatePRReturn';

@Injectable({
  providedIn: 'root',
})
export class PRReturnService {
  private readonly baseUrl = environment.baseUrl + 'PRReturn';

  constructor(private http: HttpClient) {}

  /** Get a new blank invoice with default values */
  newInvoice(): Observable<Result<PRReturnResponse>> {
    return this.http.get<Result<PRReturnResponse>>(`${this.baseUrl}/New`);
  }

  /** Get invoice by ID */
  getInvoice(id: number): Observable<Result<PRReturnResponse>> {
    return this.http.get<Result<PRReturnResponse>>(`${this.baseUrl}/Get/${id}`);
  }

  /** Create a new invoice */
  createInvoice(model: CreatePRReturn): Observable<Result<number>> {
    return this.http.post<Result<number>>(`${this.baseUrl}/Create`, model);
  }

  /** Edit existing invoice */
  editInvoice(model: CreatePRReturn): Observable<Result<number>> {
    return this.http.put<Result<number>>(`${this.baseUrl}/Edit`, model);
  }

  /** Delete invoice by ID */
  deleteInvoice(id: number): Observable<Result<number>> {
    return this.http.delete<Result<number>>(`${this.baseUrl}/Delete/${id}`);
  }
  GetAll(from, to): Observable<PRReturnResponse[]> {
    const params = new HttpParams().set('from', from).set('to', to);

    return this.http.get<PRReturnResponse[]>(`${this.baseUrl}/GetAll`, {
      params,
    });
  }
}

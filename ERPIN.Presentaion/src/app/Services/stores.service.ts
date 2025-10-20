import { Injectable } from '@angular/core';
import { environment } from '../../environments/environment';
import { HttpClient } from '@angular/common/http';
import { SelectListItem } from '../Interfaces/Response/SelectListItem';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class StoresService {
  baseUrl = environment.baseUrl + 'Stores/';

  constructor(private httpClient: HttpClient) {}

  GetAllSelectList(): Observable<SelectListItem[]> {
    const url = this.baseUrl + 'GetAllSelectList';
    return this.httpClient.get<SelectListItem[]>(url);
  }
}

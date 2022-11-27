import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { map } from 'rxjs';
import { environment } from 'src/environments/environment';
import { ContactSearchParamsModel } from '../models/contact-search-params.model';
import { ContactModel } from '../models/contact.model';
import { PaginatedResultModel } from '../models/paginated-result.model';

@Injectable({
  providedIn: 'root',
})
export class ContactsService {

  private baseUrl = `${environment.apiUrl}people/`;

  constructor(private http: HttpClient) {}

  findContacts(searchParams: ContactSearchParamsModel) {
    let params = this.getPaginationHeaders(searchParams);
    let url = `${this.baseUrl}search`;
    return this.getPaginatedResults<ContactModel[]>(url, params);
  }

  deleteContact(id: number) {
    let url = `${this.baseUrl}${id}`;
    return this.http.delete(url);
  }

  private getPaginationHeaders(params: ContactSearchParamsModel): HttpParams {
    let parameters = new HttpParams();
    parameters = parameters.append('pageNumber', params.pageNumber?.toString());
    parameters = parameters.append('pageSize', params.pageSize?.toString());
    parameters = parameters.append('orderBy', params.orderBy);
    parameters = parameters.append('orderDirection', params.orderDirection);
    if (params.query) {
      parameters = parameters.append('query', params.query);
    }
    if (params.genderId && params.genderId > 0) {
      parameters = parameters.append('genderId', params.genderId);
    }
    if (params.regionIds && params.regionIds.length > 0) {
      params.regionIds.forEach((id) => {
        parameters = parameters.append('regionIds', id);
      });
    }
    return parameters;
  }

  private getPaginatedResults<T>(url: string, params: HttpParams) {
    const paginatedResult: PaginatedResultModel<T> =
      new PaginatedResultModel<T>();
    return this.http.get<T>(url, { observe: 'response', params }).pipe(
      map((response) => {
        paginatedResult.result = response.body as T;
        if (response.headers.get('Pagination') !== null) {
          var pagination = response.headers.get('Pagination');
          paginatedResult.pagination = JSON.parse(pagination ?? '');
        }
        return paginatedResult;
      })
    );
  }
}

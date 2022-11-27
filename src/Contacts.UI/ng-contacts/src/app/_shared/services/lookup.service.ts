import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, of, shareReplay, switchMap, timer } from 'rxjs';
import { environment } from 'src/environments/environment';
import { SearchOptionsModel } from '../models/search-options.model';

@Injectable({
  providedIn: 'root',
})
export class LookupService {

  searchOptionsCache$: Observable<SearchOptionsModel> | undefined;

  baseUrl = environment.apiUrl;

  cachedProviderSearchOptions$!: Observable<SearchOptionsModel>;

  constructor(private http: HttpClient) {}

  getSearchOptions(): Observable<SearchOptionsModel> {
    if (!this.searchOptionsCache$) {
      let oneHour = 60 * 60 * 1000;
      let url = `${this.baseUrl}people/searchoptions`;
      const timer$ = timer(0, oneHour);
      this.searchOptionsCache$ = timer$.pipe(
        switchMap((_) => this.http.get<SearchOptionsModel>(url)),
        shareReplay(1)
      );
    }
    return this.searchOptionsCache$;
  }

}

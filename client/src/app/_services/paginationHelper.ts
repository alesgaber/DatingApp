import { HttpClient, HttpParams } from '@angular/common/http';
import { map } from 'rxjs/operators';
import { PaginatedResult } from '../_model/pagination';

export function getPaginationHeaders(pageNumber: number, pageSize: number) {
    let params = new HttpParams();

    params = params.append('pageNumber', pageNumber.toString());
    params = params.append('pageSize', pageSize.toString());

    return params;
  }

export  function getPaginatedResult<T>(url, params: HttpParams, http: HttpClient) {
    const pagintedResult: PaginatedResult<T> = new PaginatedResult<T>();
    return (
      http
        // tako dobimo full response back, not just content of the body
        .get<T>(url, { observe: 'response', params })
        .pipe(
          map((response) => {
            pagintedResult.result = response.body;
            if (response.headers.get('Pagination') !== null) {
              pagintedResult.pagination = JSON.parse(
                response.headers.get('Pagination')
              );
            }
            return pagintedResult;
          })
        )
    );
  }

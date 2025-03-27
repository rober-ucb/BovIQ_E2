import { HttpClient } from "@angular/common/http";
import { inject } from "@angular/core";
import { environment } from "@enviroments/environment";
import { Observable } from "rxjs";

export class BaseApiService {
    private readonly baseUrl: string = '';
    public readonly httpClient: HttpClient = inject(HttpClient);

    constructor(protected baseApi: string = '') {
      this.baseUrl = environment.API_BASE_PATH + baseApi;
    }
    
    public get<T>(url: string, options?: object): Observable<T> {
      url = this.baseUrl + url;
      return this.httpClient.get<T>(url, options);
    }

    public post<T>(url: string, body?: object, options?: object): Observable<T> {
      url = this.baseUrl + url;
      return this.httpClient.post<T>(url, body, options);
    }

    public put<T>(url: string, body?: object, options?: object): Observable<T> {
      url = this.baseUrl + url;
      return this.httpClient.put<T>(url, body, options);
    }
    
    public delete<T>(url: string, options?: object): Observable<T> {
      url = this.baseUrl + url;
      return this.httpClient.delete<T>(url, options);
    }
  }
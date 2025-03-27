import { Injectable } from '@angular/core';
import { BaseApiService } from '@app/core/models/base.api.service';
import { BreedResponse, CreateBreedRequest, UpdateBreedRequest } from '@app/core/models/breeds/breed';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class BreedService extends BaseApiService {
  constructor() {
    super('/Breeds');
  }

  public getAll(): Observable<BreedResponse[]> {
    return super.get(``);
  }
  public add(request: CreateBreedRequest): Observable<number> {
    return super.post(``, request);
  }
  public update(id:number, request: UpdateBreedRequest): Observable<number> {
    return super.put(`/${id}`, request);
  }
  public deleteB(id: number): Observable<number> {
    return super.delete(`/${id}`);
  }
  public getById(id: number): Observable<BreedResponse> {
    return super.get(`/${id}`);
  }
}

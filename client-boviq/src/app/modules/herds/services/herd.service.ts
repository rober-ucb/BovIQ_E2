import { Injectable } from '@angular/core';
import { BaseApiService } from '@app/core/models/base.api.service';
import { CreateHerdRequest, HerdResponse } from '@app/core/models/herds/herd';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class HerdService extends BaseApiService {
  constructor() {
    super('/Herds');
  }
  public addHerd(request: CreateHerdRequest): Observable<number> {
    return super.post(``, request);
  }
  public getAll(): Observable<HerdResponse[]> {
    return super.get(``);
  }
  public getHerdById(id: number): Observable<HerdResponse> {
    return super.get(`${id}`);
  }
  public updateHerd(id: number, request: CreateHerdRequest): Observable<any> {
    return super.put(`${id}`, request);
  }
  public deleteHerd(id: number): Observable<any> {
    return super.delete(`${id}`);
  }
}

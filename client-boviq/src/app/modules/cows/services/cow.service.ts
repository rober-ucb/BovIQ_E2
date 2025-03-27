import { Injectable } from '@angular/core';
import { BaseApiService } from '@app/core/models/base.api.service';
import { Cattle } from '@app/core/models/cows/cow';
import { Observable, of } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class CattleService extends BaseApiService{

  constructor() { 
    super('/Cows');
  }

  getCattleList(): Observable<Cattle[]> {
    return super.get('')
  }

  getCattleById(id: number): Observable<Cattle> {
    return super.get(`/${id}`);
  }

  addCattle(cattle: Cattle): Observable<Cattle> {
    return super.post('', cattle);
  }

  updateCattle(id: number, cattle: Cattle): Observable<Cattle> {
    return super.put(`/${id}`, cattle);
  }

  deleteCattle(id: number): Observable<boolean> {
    return super.delete(`/${id}`);
  }
}

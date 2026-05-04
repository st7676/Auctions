import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ApiService {

  private baseUrl = 'https://localhost:7208/api';

  constructor(private http: HttpClient) {}

  getAuctions(): Observable<any[]> {
    return this.http.get<any[]>(`${this.baseUrl}/Auctions`);
  }
  placeBid(auctionId: number, amount: number) {
  return this.http.post('https://localhost:7208/api/Bids', {
    auctionId,
    amount
  });
}
}
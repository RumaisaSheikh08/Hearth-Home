import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class GetcatalogueService {
  private apiURL = "https://localhost:7176/api/Products/getallproducts";

  constructor(private httpClient: HttpClient) { }

  getData(): Observable<any>
  {
    return this.httpClient.get<any>(this.apiURL);
  }
}

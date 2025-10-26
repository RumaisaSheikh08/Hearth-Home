import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class GetcataloguecategoryService {
  private apiUrl = 'https://localhost:7176/api/Products/getproductbycategory';
  constructor(private httpClient: HttpClient) { }

  getDataByCategory(categoryName: string) : Observable<any>
  {
    return this.httpClient.get<any>(this.apiUrl,{
      params : {categoryName}
    });
  }
}

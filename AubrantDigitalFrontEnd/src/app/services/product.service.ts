import { Injectable } from '@angular/core';
import { HttpClient, HttpParams  } from '@angular/common/http';
import { Observable,throwError } from 'rxjs';
import { catchError } from 'rxjs/operators';
import { environment } from '../app.config';
import { Product } from '../models/product.model';

@Injectable({
  providedIn: 'root',
})
export class ProductService {
  private apiUrl = environment.apiUrl + 'api/products';

  constructor(private http: HttpClient) {}

  getProducts(sortBy: string = 'name', sortOrder: string = 'asc', take: number = 5, skip: number = 0): Observable<Product[]> {
    let params = new HttpParams()
      .set('sortBy', sortBy)
      .set('sortOrder', sortOrder)
      .set('take', take.toString())
      .set('skip', skip.toString());

      return this.http.get<Product[]>(this.apiUrl, { params }).pipe(
        catchError((error) => {
          console.error('Error fetching products:', error);
          return throwError(() => new Error('Unable to fetch products. Please try again later.'));
        })
      );
  }
}

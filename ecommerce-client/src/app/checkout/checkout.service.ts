import { IOrderToCreate } from './../shared/models/order';
import { IDeliverMethod } from './../shared/models/deliveryMethod';
import { map } from 'rxjs/operators';
import { HttpClient } from '@angular/common/http';
import { environment } from './../../environments/environment';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class CheckoutService {
  baseUrl = environment.apiUrl;

  constructor(private http: HttpClient) { }

  // tslint:disable-next-line: typedef
  createOrder(order: IOrderToCreate) {
    return this.http.post(this.baseUrl + 'orders', order);
  }

  // tslint:disable-next-line: typedef
  getDeliveryMethods() {
    return this.http.get(this.baseUrl + 'orders/deliveryMethods')
      .pipe(
        map((dm: IDeliverMethod[]) => {
          return dm.sort((a, b) => b.price - a.price);
        })
      );
  }
}

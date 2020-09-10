import { BasketService } from './../../../basket/basket.service';
import { IBasketTotals } from './../../models/basket';
import { Observable } from 'rxjs';
import { Component, OnInit, Input } from '@angular/core';

@Component({
  selector: 'app-order-totals',
  templateUrl: './order-totals.component.html',
  styleUrls: ['./order-totals.component.scss']
})
export class OrderTotalsComponent implements OnInit {
  // basketTotal$: Observable<IBasketTotals>;
  @Input() shippingPrice: number;
  @Input() subtotal: number;
  @Input() total: number;

  constructor(/* private basketService: BasketService */) { }

  ngOnInit(): void {
    // this.basketTotal$ = this.basketService.basketTotal$;
  }

}

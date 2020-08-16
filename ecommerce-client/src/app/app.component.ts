import { AccountService } from './account/account.service';
import { BasketService } from './basket/basket.service';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent implements OnInit {
  title = 'E-Commerce';

  constructor(private basketService: BasketService, private acctService: AccountService) {}

  ngOnInit(): void {
    this.loadBasket();
    this.loadCurrentUser();
  }

  // tslint:disable-next-line: typedef
  loadCurrentUser() {
    const token = localStorage.getItem('token');
    // if (token) {
    this.acctService.loadCurrentUser(token).subscribe(() => {
      console.log('user loaded!');
    }, error => {
      console.log(error);
    });
    // }
  }

  // tslint:disable-next-line: typedef
  loadBasket() {
    const basketId = localStorage.getItem('basket_id');
    if (basketId) {
      this.basketService.getBasket(basketId).subscribe(() => {
        console.log('basket initialized!');
      }, error => {
        console.log(error);
      });
    }
  }
}

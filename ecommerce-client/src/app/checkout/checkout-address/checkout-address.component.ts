import { AccountService } from './../../account/account.service';
import { FormGroup } from '@angular/forms';
import { Component, OnInit, Input } from '@angular/core';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-checkout-address',
  templateUrl: './checkout-address.component.html',
  styleUrls: ['./checkout-address.component.scss']
})
export class CheckoutAddressComponent implements OnInit {
  @Input() checkoutForm: FormGroup;

  constructor(private acctService: AccountService, private toastr: ToastrService) { }

  ngOnInit(): void {
  }

  // tslint:disable-next-line: typedef
  saveUserAddress() {
    this.acctService.updateUserAddress(this.checkoutForm.get('addressForm').value).subscribe(() => {
      this.toastr.success('Address saved successfully!');
    }, error => {
      this.toastr.error(error.message);
      console.log(error);
    });
  }

}

import { Component, OnInit } from '@angular/core';
import { OrdersService } from '../_services/orders.service';
import { AlertifyService } from '../_services/alertify.service';
@Component({
  selector: 'app-user-order',
  templateUrl: './user-order.component.html',
  styleUrls: ['./user-order.component.css']
})
export class UserOrderComponent implements OnInit {

  userid = 1
  data: {};
  constructor(private ordersservice: OrdersService ,private alertify: AlertifyService) { }

  ngOnInit() {
    this.getorders();
  }
  getorders() {
    this.ordersservice.getOrders(this.userid)
      .subscribe((res: any) => { this.data = res; console.log(res); }, (error) => console.log(error));
  }
  deleteorder(id:any) {
    this.ordersservice.deleteOrder(id).subscribe(() => {
      this.alertify.success('Registration Successful');
    }, erro => {
      this.alertify.error('Registration Failed');
    });
    console.log(id);
  }

}

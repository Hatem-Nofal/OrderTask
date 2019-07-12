import { Component, OnInit, EventEmitter, Output } from '@angular/core';
import { OrdersService } from '../_services/orders.service';
import { AlertifyService } from '../_services/alertify.service';
import { Units } from '../Model/Units';
import { Order } from '../Model/Order';
import { Items } from '../Model/Items';

@Component({
  selector: 'app-add-order',
  templateUrl: './add-order.component.html',
  styleUrls: ['./add-order.component.css']
})
export class AddOrderComponent implements OnInit {
  @Output() cancelAddOrder = new EventEmitter();

  model = new Order();
  items = [];
  orderitemlist: Array<Items>;
  constructor(private orderservice: OrdersService, private alertify: AlertifyService) { }

  ngOnInit() {
    this.orderitemlist = [];
    this.getitems();
  }
  getitems() {
    this.orderservice.getitems().subscribe((res: any[]) => { this.items = res; console.log(res); }, (error) => console.log(error));
  }

  addordertolist() {
    let itemobj = new Items();
    itemobj.itemid = 1;
    itemobj.amount = 2;
    itemobj.itemsname = 'pesp';
    itemobj.userId = 1;
    this.orderitemlist.push(itemobj);

  }
  addOrder() {
    console.log(this.orderitemlist);
    this.orderservice.insertOrders(this.orderitemlist).subscribe(() => {
      this.alertify.success('Order Has Add Successful');
    }, erro => {
      this.alertify.error('Added Order Failed');
    });
    
  }
  changeitem(e) {
    // this.orderitem.itemid = e.;
    // this.orderitem.itemsname=e.target.value;



  }
  cancel() {
    this.cancelAddOrder.emit(false);

  }

}

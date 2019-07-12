import { Component, OnInit } from '@angular/core';
import { AlertifyService } from '../_services/alertify.service';
import { UsersService } from '../_services/users.service';

@Component({
  selector: 'app-users',
  templateUrl: './users.component.html',
  styleUrls: ['./users.component.css']
})
export class UsersComponent implements OnInit {

  constructor(private usersService: UsersService, private alertify: AlertifyService) { }
  data: {};

  ngOnInit() {
    this.getUsers();
  }
  getUsers() {
    this.usersService.getUsers()
      .subscribe((res: any) => { this.data = res; console.log(res); }, (error) => console.log(error));
  }
  deleteUser(id: number) {
    this.usersService.DeleteUser(id).subscribe(() => {
      this.alertify.success('User Delete Successful');
    }, erro => {
      this.alertify.error('User Delete Failed');
    });
    console.log(id);
  }

}

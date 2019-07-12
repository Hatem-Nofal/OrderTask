import { Component, OnInit, Output, EventEmitter } from '@angular/core';
import { AuthService } from '../_services/auth.service';
import { UserModel } from '../Model/UserModel';
import { AlertifyService } from '../_services/alertify.service';

@Component({
  selector: 'app-add-user',
  templateUrl: './add-user.component.html',
  styleUrls: ['./add-user.component.css']
})
export class AddUserComponent implements OnInit {
  @Output() cancelRegister = new EventEmitter();

  model = new UserModel();
  Roles: any = ["Admin", "Normal"];
  constructor(private auhtService: AuthService, private alertify: AlertifyService) { }

  ngOnInit() {
   
  }
  changeRole(e) {
    this.model.role = e.target.value;
  }


  adduser() {
    this.auhtService.register(this.model).subscribe(() => {
      this.alertify.success('ADD User Successful');
    }, erro => {
      this.alertify.error('ADD User Failed');
    });
  }
  cancel() {
    this.cancelRegister.emit(false);
  }

}

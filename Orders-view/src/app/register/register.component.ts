import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';
import { AuthService } from '../_services/auth.service';
import { AlertifyService } from '../_services/alertify.service';
import { UserModel } from '../Model/UserModel';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {
  @Output() cancelRegister = new EventEmitter();
  model = new UserModel();
 
  

  constructor(private auhtService: AuthService, private alertify: AlertifyService) { }

  ngOnInit() {
  }


  register() {
    this.auhtService.register(this.model).subscribe(() => {
      this.alertify.success('Registration Successful');
    }, erro => {
      this.alertify.error('Registration Failed');
    });
  }
  cancel() {
    this.cancelRegister.emit(false);
  }

}

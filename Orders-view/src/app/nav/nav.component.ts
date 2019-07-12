import { Component, OnInit } from '@angular/core';
import { AuthService } from '../_services/auth.service';
import { AlertifyService } from '../_services/alertify.service';
import { Router, ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-nav',
  templateUrl: './nav.component.html',
  styleUrls: ['./nav.component.css']
})
export class NavComponent implements OnInit {
  userRole = "Admin";
  useradmin=false;
  model: any = {};
  constructor(private authService: AuthService , private alertify: AlertifyService ,private route : ActivatedRoute,  private router: Router) { }

  ngOnInit() {
    if (this.userRole=="Admin") {
      this.useradmin=true;
      }
  }

  login() {
    this.authService.login(this.model).subscribe(next => {
      this.alertify.success('login sucess');
    }, erro => {
      this.alertify.error('UserName or Passwrod wrong');
    }, () => {
      this.router.navigate(['/members']);
    });
  }

  loggedIn() {

    return this.authService.loggedIn();
  }
  logOut() {
    localStorage.removeItem('token');
    this.alertify.message('Logged Out');
    this.router.navigate(['/home']);
  }
}

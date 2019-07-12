import { BrowserModule } from '@angular/platform-browser';
import { NgModule,CUSTOM_ELEMENTS_SCHEMA  } from '@angular/core';
import { HttpClientModule } from '@angular/common/http';
import { AppComponent } from './app.component';
import { NavComponent } from './nav/nav.component';
import { FormsModule } from '@angular/forms';
import { AuthService } from './_services/auth.service';
import { HomeComponent } from './home/home.component';
import { RegisterComponent } from './register/register.component';
import { AlertifyService } from './_services/alertify.service';
import { ErrorinterceptorProvide } from './_services/error.interceptor';
import { BsDropdownModule } from 'ngx-bootstrap';
import { routing } from './routes';
import { AuthGuard } from './_guards/auth.guard';
import { HashLocationStrategy, LocationStrategy } from '@angular/common';
import { from } from 'rxjs';
import { AddOrderComponent } from './add-order/add-order.component';
import { UserOrderComponent } from './user-order/user-order.component';
import { AddUserComponent } from './add-user/add-user.component';
import { UsersComponent } from './users/users.component';


@NgModule({
   declarations: [
      AppComponent,
      NavComponent,
      HomeComponent,
      RegisterComponent,
      AddOrderComponent,
      UserOrderComponent,
      AddUserComponent,
      UsersComponent,

   ],
   imports: [
      BrowserModule,
      HttpClientModule,
      FormsModule,
      BsDropdownModule.forRoot()
      , routing
   ],
   providers: [
      AuthService,
      AlertifyService,
      ErrorinterceptorProvide,
      AuthGuard
      , { provide: LocationStrategy, useClass: HashLocationStrategy },
      
   ],
   bootstrap: [
      AppComponent
   ],schemas: [
      CUSTOM_ELEMENTS_SCHEMA
  ],
})
export class AppModule { }

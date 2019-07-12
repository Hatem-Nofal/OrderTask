import { Routes, RouterModule } from '@angular/router';
import { HomeComponent } from './home/home.component';
import { AddOrderComponent } from './add-order/add-order.component';
import { UserOrderComponent } from './user-order/user-order.component';
import { AddUserComponent } from './add-user/add-user.component';
import { UsersComponent } from './users/users.component';
import { AuthGuard } from './_guards/auth.guard';

export const appRoutes: Routes = [
    { path: '', component: HomeComponent },
    {
        path: '',
        runGuardsAndResolvers: 'always',
        canActivate: [AuthGuard],
        children: [
            { path: 'MyOrders', component: UserOrderComponent },
            { path: 'AddOrder', component: AddOrderComponent },
            { path: 'AddUser', component: AddUserComponent },
            { path: 'Users', component: UsersComponent }

        ]
    }
    ,
    { path: '**', redirectTo: '', pathMatch: 'full' }

];
export const routing = RouterModule.forRoot(appRoutes);

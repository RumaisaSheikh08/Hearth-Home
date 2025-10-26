import { Routes } from '@angular/router';
import { RegisteruserComponent } from './components/registeruser/registeruser.component';
import { LoginuserComponent } from './components/loginuser/loginuser.component';
import { CatalogueComponent } from './components/catalogue/catalogue.component';
import { RoomsComponent } from './components/rooms/rooms.component';
import { HomepageComponent } from './components/homepage/homepage.component';
import { RoomdetailsComponent } from './components/roomdetails/roomdetails.component';
import { AddcartComponent } from './components/addcart/addcart.component';
import { CheckoutformComponent } from './components/checkoutform/checkoutform.component';
import { PaymentstatusComponent } from './components/paymentstatus/paymentstatus.component';
import { LogoutComponent } from './components/logout/logout.component';

export const routes: Routes = [
    {path: '' , redirectTo: 'home' , pathMatch:'full' },
    {path: 'home', component: HomepageComponent},
    {path: 'registeruser' , component: RegisteruserComponent},
    {path: 'loginuser' , component: LoginuserComponent},
    {path: 'catalogue', component: CatalogueComponent},
    {path: 'rooms/:categoryName' , component: RoomsComponent},
    {path: 'roomdetails' , component: RoomdetailsComponent},
    {path: 'addtocart' , component: AddcartComponent},
    {path: 'payorder' ,component: CheckoutformComponent},
    {path: 'paymentstatus' , component: PaymentstatusComponent},
    {path: 'logout' , component: LogoutComponent}
];

import { Component } from '@angular/core';
import { RoomdatatransferService } from '../../services/roomdatatransfer.service';
import { OnInit } from '@angular/core';
import { FormsModule } from "@angular/forms";
import { NgFor, CommonModule , NgIf} from '@angular/common';
import { last } from 'rxjs';
import { Router } from '@angular/router';

@Component({
  selector: 'app-addcart',
  imports: [FormsModule, CommonModule],
  templateUrl: './addcart.component.html',
  styleUrl: './addcart.component.css'
})
export class AddcartComponent {
  cardItems: any[] = [];
  dataCart: any;
  lastData: any;
  orderValid: any[] = [];
  totalAmount: any;
  shipping : any;
  salesTax: any;
  estimatedTotal :any;
  paymentDetails : any = {};

  constructor(private roomDetailsData: RoomdatatransferService, private router: Router ){}

  ngOnInit() : void{
    //first time - cart empty - localstorage with the user id is empty - setItem
    //other times - the last data needs to be retrieved from localstorage - getItem and the new + last must be added 
    //last must be removed
    this.roomDetailsData.currentData.subscribe(data => {
      this.maintainCart(data);
      this.calculateSum();
    })
  }

  maintainCart(data : any[]){
    this.dataCart = localStorage.getItem("UserID");// if this is empty means no prior item in cart
    if(!this.dataCart){
      console.log("Cart Items are Empty");
      this.cardItems[0] = data;
      localStorage.setItem("UserID" , JSON.stringify(this.cardItems));
    }
    else{
      console.log("Cart is not empty" , this.cardItems);
      this.lastData = JSON.parse(this.dataCart);
      this.lastData.push(data);
      this.cardItems = this.lastData;
      console.log("Cart items are:" , this.cardItems);
      localStorage.setItem("UserID" , JSON.stringify(this.cardItems));
    }
  }

  removeItem(productId: any): void{
     console.log("The product that needs to be removed: ", productId);
     this.cardItems = this.cardItems.filter(item => item && item.productId !== productId);
     localStorage.setItem("UserID" , JSON.stringify(this.cardItems));
     this.router.navigate(["/addtocart"]);

}
calculateSum() : void{
  this.orderValid = this.cardItems.filter(item => item);
  const orderAmounts : number [] = this.orderValid.map((item) => item.price * item.quantity);
  this.totalAmount = orderAmounts.reduce((accumalator , currentValue) => accumalator + currentValue,0);
  this.totalAmount = !this.totalAmount.NaN ? this.totalAmount : 0; 
  this.shipping = !this.totalAmount.NaN ? 100 : 0;
  this.salesTax = 5;//this.totalAmount * 0.05;
  this.estimatedTotal = this.totalAmount + this.shipping + (this.totalAmount * 0.05);
  localStorage.setItem("CartItemUser" , this.orderValid.length.toString());
}
AddCart() : void{
    console.log("Total Amount is: ", this.totalAmount);
    this.paymentDetails = {
      totalAmount : this.totalAmount,
      estimatedTotal : this.estimatedTotal,
      shipping : this.shipping,
      salesTax : this.salesTax,
    };
    
    localStorage.setItem("PaymentDetails" + "UserID" , JSON.stringify(this.paymentDetails));
    this.router.navigate(["/payorder"]);
}
}

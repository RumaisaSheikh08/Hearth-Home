import { Component } from '@angular/core';

@Component({
  selector: 'app-paymentstatus',
  imports: [],
  templateUrl: './paymentstatus.component.html',
  styleUrl: './paymentstatus.component.css'
})
export class PaymentstatusComponent {
  constructor(){
  }

  ngOnInIt() : void{
    localStorage.removeItem("CartItemUser");
    localStorage.removeItem("UserID");
    localStorage.setItem("CartItemUser" , "0");
  }
}

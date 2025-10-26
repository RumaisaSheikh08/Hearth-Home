import { Component } from '@angular/core';
import { RouterLink } from '@angular/router';
import { CommonModule } from '@angular/common';
@Component({
  selector: 'app-navbar',
  imports: [RouterLink,CommonModule],
  templateUrl: './navbar.component.html',
  styleUrl: './navbar.component.css'
})
export class NavbarComponent {
  userinformation :any;
  cartItemLength = localStorage.getItem("CartItemUser");
  ngOnInit() : void{
    const data = localStorage.getItem("UserInformation");
    if(data){
      this.userinformation = JSON.parse(data);
      console.log("User Information: " , this.userinformation);
    }
  }
 
}

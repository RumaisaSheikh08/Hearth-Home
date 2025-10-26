import { Component, OnInit } from '@angular/core';
import { RoomdatatransferService } from '../../services/roomdatatransfer.service';
import { NgFor ,CommonModule } from '@angular/common';
import { Router } from '@angular/router';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-roomdetails',
  standalone: true,
  imports: [CommonModule,FormsModule],
  templateUrl: './roomdetails.component.html',
  styleUrl: './roomdetails.component.css'
})
export class RoomdetailsComponent{
  roomDetailsData: any;
  roomData : any;
  itemQuantity: any;
  constructor(private roomDataTransfer : RoomdatatransferService,private router: Router){}

  ngOnInit(): void {
    this.roomData = localStorage.getItem("RoomDetailsData");
    if(this.roomData)
    {
      console.log("Data exists in local storage", this.roomData);
      const retrivedData = JSON.parse(this.roomData);
      this.roomDetailsData = retrivedData;
    }
    else{
      this.roomDataTransfer.currentData.subscribe(data => {
        console.log("Room recieved data: " , data);
        this.roomDetailsData = data;
      })
    }   
  }

  AddtoCart(): void{
    if(this.itemQuantity == null)
    {    
      this.roomDetailsData.quantity = 1;
    }
    else{
      this.roomDetailsData.quantity = this.itemQuantity;
    } 
    console.log("Quantity of the item is: " , this.roomDetailsData.quantity)
    this.roomDataTransfer.changeData(this.roomDetailsData);
    this.router.navigate(["/addtocart"]);   
  }
}


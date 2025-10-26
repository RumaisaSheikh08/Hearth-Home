import { Component } from '@angular/core';
import { FormBuilder, Validators } from '@angular/forms';
import { FormGroup } from '@angular/forms';
import { ReactiveFormsModule } from '@angular/forms';
import { CommonModule, NgIf } from '@angular/common';
import { Router } from '@angular/router';

@Component({
  selector: 'app-checkoutform',
  standalone: true,
  imports: [ReactiveFormsModule,NgIf],
  templateUrl: './checkoutform.component.html',
  styleUrl: './checkoutform.component.css'
})
export class CheckoutformComponent {
  paymentDetails! : FormGroup;
  amountDetails: any;
  constructor(private formBuilder : FormBuilder, private router: Router){}

  ngOnInit(): void{
    this.paymentDetails = this.formBuilder.group({
      CardNumber : ['' ,[Validators.required ,Validators.minLength (16)]],
      ExpiryDate : ['' , Validators.required],
      CVV: ['' , [Validators.required , Validators.minLength(3)]],
      NameOnCard: ['' , Validators.required] 
    });

    this.amountDetails = localStorage.getItem("PaymentDetails" + "UserID");
    this.amountDetails = JSON.parse(this.amountDetails);
    console.log("Payment Details: " , this.amountDetails);
  }

  paymentDetailsForm() : void{
    if(this.paymentDetails.valid){
      console.log("Valid Values", this.paymentDetails);
      this.router.navigate(["/paymentstatus"]);
    }
    else
    {
      console.log("Invalid Values", this.paymentDetails);
    }
  }
}

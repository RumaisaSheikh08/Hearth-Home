import { Component } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { NgIf } from '@angular/common';
import { ReactiveFormsModule } from '@angular/forms';
import { HttpClient } from '@angular/common/http';
import { RouterLinkActive } from '@angular/router';
import { RouterLink } from '@angular/router';
import { Router } from '@angular/router';
@Component({
  selector: 'app-loginuser',
  imports: [NgIf, ReactiveFormsModule, RouterLinkActive, RouterLink],
  templateUrl: './loginuser.component.html',
  styleUrl: './loginuser.component.css'
})
export class LoginuserComponent {
  loginUserForm! : FormGroup;

  constructor(private formBuilder: FormBuilder, private httpClient : HttpClient, private router : Router){}

  ngOnInit() : void{
    this.loginUserForm = this.formBuilder.group({
      Email: ['' ,Validators.required],
      PasswordHash: ['' , Validators.required]
    })
  }

  submitLoginForm() : void{
    if(this.loginUserForm.valid)
    {
      const apiURL = 'https://localhost:7176/api/User/login';
      this.httpClient.post(apiURL , this.loginUserForm.value)
      .subscribe({
        next: (response:any)=>{
          console.log("API Response: ", response);
          if(response.status == "AUTHORIZED" && response.token != "")
          {
            localStorage.setItem('UserInformation' , JSON.stringify(response));
            localStorage.setItem('authToken' , response.token);
            this.router.navigate(['/catalogue']);
          }
        },
        error: (err) =>{
          console.log("Error Response: ", err);
        }
      })
      console.log("Valid value: ", this.loginUserForm.value);
    }
    else
    {
      console.log("Invalid value: ", this.loginUserForm.value);
    }
  }
}

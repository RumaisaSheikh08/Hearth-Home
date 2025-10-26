import { Component } from '@angular/core';
import { NgIf } from '@angular/common';
import { FormBuilder, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';
import { HttpClient } from '@angular/common/http';
import { ActivatedRoute, Router } from '@angular/router';
@Component({
  selector: 'app-registeruser',
  imports: [NgIf, ReactiveFormsModule],
  templateUrl: './registeruser.component.html',
  styleUrl: './registeruser.component.css'
})
export class RegisteruserComponent {
  signUpForm! : FormGroup;
  constructor (private formBuilder: FormBuilder,private httpClient : HttpClient, private route: ActivatedRoute, private router: Router){

  }

  ngOnInit() : void{
    this.signUpForm = this.formBuilder.group({
      Name : ['' , Validators.required],
      Email: ['' , Validators.required],
      PasswordHash: ['' , Validators.required],
      ConfirmPassword: ['' , Validators.required],
    })


  }
  submitRegisterUser(): void{
    if(this.signUpForm.valid)
    {
      console.log('Form Value: ' , this.signUpForm.value)
      const apiUrl = 'https://localhost:7176/api/User/register';
      this.httpClient.post(apiUrl, this.signUpForm.value)
      .subscribe({
        next: (response: any) =>{
          console.log('Response Received', response);
        },
        error: (err) =>{
          console.log('Error received' , err);
        }

      })
    }
    else
    {
      console.log('Invalid Value: ' , this.signUpForm.value)
    }
  }

}

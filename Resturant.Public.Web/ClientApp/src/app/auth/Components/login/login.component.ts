import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { User } from '../../Models/User';
import { AuthService } from '../../Service/auth.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {
  LoginForm: FormGroup;
  RegisterForm: FormGroup;
  userForLogin: User;
  userForRegister: User;
  constructor(private FbForLogin: FormBuilder, private FbForRegister: FormBuilder, private AuthService: AuthService) { }

  ngOnInit() {
    this.CreateLoginForm();
    this.CreateRegisterForm();
  }

  // create Login Form
  CreateLoginForm() {
    this.LoginForm = this.FbForLogin.group({
      password: ['', [Validators.required]],
      email: ['', [Validators.required, Validators.email]]
    })
  }

  // Create Register Form

  CreateRegisterForm() {
    this.RegisterForm = this.FbForRegister.group({
      password: ['', [Validators.required, Validators.min(6)]],
      email: ['', [Validators.required, Validators.email]],
      firstname: ['', Validators.required],
      lastname: ['', Validators.required]
    })
  }

  // // Login Function
  // Login(){
  //   if(this.LoginForm.valid){
  //     this.userForLogin = Object.assign({}, );
  //       this.AuthService.Login(this.LoginForm.value).subscribe(
  //         {
  //           next: (result:any)=>{console.log("Login Succes",result);},
  //           error:(error:any)=>{console.log("Login Error",error);}
  //         }
  //      )
  //   }
  // }

  // // Register Function
  // Register(){
  //   if(this.RegisterForm.valid){
  //     this.userForRegister = Object.assign({}, );
  //       this.AuthService.Login(this.RegisterForm.value).subscribe(
  //         {
  //           next: (result:any)=>{console.log("Register Succes",result);},
  //           error:(error:any)=>{console.log("Register Error",error);}
  //         }
  //      )
  //   }
  // }

}

import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { User } from '../../Models/User';
import { AuthService } from '../../Service/auth.service';
import { NgbActiveModal } from '@ng-bootstrap/ng-bootstrap';
import { HttpClient } from '@angular/common/http';

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
  constructor(private FbForLogin: FormBuilder, private FbForRegister: FormBuilder, private AuthService: AuthService,private activeModal: NgbActiveModal,
    private httpclint:HttpClient) { }

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

  //Login Function
  Login(){
    if(this.LoginForm.valid){
      this.userForLogin = Object.assign({}, );
     const user= this.LoginForm.getRawValue();
       this.AuthService.login(this.LoginForm.value);
      // console.log({"email":user.email,"password":user.password});
      // this.httpclint.post("https://localhost:7018/api/account/login",{"email":user.email,"password":user.password},{responseType: 'json'}).subscribe(
      //   {next:(e)=>{console.log("sucess",e)},
      //   error:()=>{console.log("error")}}
      // )
    }
    return;
  }

  // Register Function
  Register(){
    if(this.RegisterForm.valid){
      this.userForRegister = Object.assign({}, );
      console.log(this.RegisterForm.value);
        this.AuthService.Register(this.RegisterForm.value);
    }
  }


  closeModal() {
    this.activeModal.close('Modal Closed');
  }

}

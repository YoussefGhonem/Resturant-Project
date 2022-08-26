import { BaseComponent } from './../../../../@shared/base/base.component';
import { Component, Injector, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { User } from '../../Models/User';
import { AuthService } from '../../Service/auth.service';
import { NgbActiveModal } from '@ng-bootstrap/ng-bootstrap';
import { HttpClient } from '@angular/common/http';
import { AuthController } from 'app/auth/Controllers/Auth';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent extends BaseComponent implements OnInit {
  loginForm: FormGroup;
  registerForm: FormGroup;
  userForLogin: User;
  userForRegister: User;

  constructor(public override injector: Injector, public modalService: NgbActiveModal,
    private formBuilder: FormBuilder) {
    super(injector);
  }

  ngOnInit() {
    this.initForm();
  }

  initForm() {
    this.CreateLoginForm();
    this.CreateRegisterForm();
  }

  // create Login Form
  CreateLoginForm() {
    this.loginForm = this.formBuilder.group({
      password: ['', [Validators.required]],
      email: ['', [Validators.required, Validators.email]]
    })
  }
  // Create Register Form

  CreateRegisterForm() {
    this.registerForm = this.formBuilder.group({
      password: ['', [Validators.required, Validators.min(6)]],
      email: ['', [Validators.required, Validators.email]],
      firstname: ['', Validators.required],
      lastname: ['', Validators.required]
    })
  }

  //Login Function
  Login() {
    if (this.loginForm.valid) {
      let body = this.loginForm.getRawValue();
      this.authService.login(body.email, body.password);
    }
    return;
  }

  // Register Function
  Register() {
    if (this.registerForm.valid) {
      let body = this.registerForm.getRawValue();

      this.httpService.PUT(AuthController.Register, body)
        .subscribe(() => {
          this.modalService.close(true)
          this.notificationService.success("Success", "Changes updated successfully");
        });
    }
  }

  closeModal() {
    this.modalService.close('Modal Closed');
  }

}

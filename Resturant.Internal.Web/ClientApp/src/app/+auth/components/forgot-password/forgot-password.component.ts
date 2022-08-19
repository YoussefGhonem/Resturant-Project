import { BaseComponent } from '@shared/base/base.component';
import { Component, OnInit, Injector } from '@angular/core';
import { UntypedFormBuilder, UntypedFormGroup, Validators } from '@angular/forms';
import { AuthService } from 'app/+auth/service';
import { IdentityController } from 'app/+auth/controllers/IdentityController';
@Component({
  selector: 'app-forgot-password',
  templateUrl: './forgot-password.component.html',
  styleUrls: ['./forgot-password.component.css']
})
export class ForgotPasswordComponent extends BaseComponent implements OnInit {
  // Login Form
  passresetForm!: UntypedFormGroup;
  submitted = false;
  fieldTextType!: boolean;
  error = '';
  returnUrl!: string;
  displayForm: boolean;
  displaySuccess: boolean;
  // set the current year
  year: number = new Date().getFullYear();

  constructor(
    public override injector: Injector,
    private _formBuilder: UntypedFormBuilder,
    private _authService: AuthService) {
    super(injector);
    this.displayForm = true;
    this.displaySuccess = false;
  }

  ngOnInit(): void {
    this.passresetForm = this._formBuilder.group({
      email: ['', [Validators.required, Validators.email]]
    });
  }

  // convenience getter for easy access to form fields
  get f() { return this.passresetForm.controls; }

  /**
   * Form submit
   */
  onSubmit() {
    this.submitted = true;

    if (this.passresetForm.invalid) {
      return;
    }

    let body = this.passresetForm.getRawValue();
    this.httpService.POST(IdentityController.ForgetPassword(body.email), {})
      .subscribe(() => {
        this.displayForm = false;
        this.displaySuccess = true;
      });
  }

}

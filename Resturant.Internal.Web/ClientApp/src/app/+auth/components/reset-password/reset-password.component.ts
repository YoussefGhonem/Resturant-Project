import { Component, OnInit, Injector } from '@angular/core';
import { UntypedFormBuilder, UntypedFormGroup, Validators } from '@angular/forms';
import { ActivatedRoute } from '@angular/router';
import { AuthService } from 'app/+auth/service';
import { BaseComponent } from '@shared/base/base.component';
import { IdentityController } from 'app/+auth/controllers/IdentityController';

@Component({
  selector: 'app-reset-password',
  templateUrl: './reset-password.component.html',
  styleUrls: ['./reset-password.component.css']
})
export class ResetPasswordComponent extends BaseComponent implements OnInit {


  // Login Form
  passresetForm!: UntypedFormGroup;
  submitted = false;
  passwordField!: boolean;
  confirmField!: boolean;
  error = '';
  returnUrl!: string;
  email: string;
  token: string;
  displaySuccess: boolean;
  displayForm: boolean;
  displayError: boolean;
  // set the current year
  year: number = new Date().getFullYear();

  constructor(
    public override injector: Injector,
    private _formBuilder: UntypedFormBuilder,
    private _activatedRoute: ActivatedRoute,
    private _authService: AuthService) {
    super(injector);
    this.email = '';
    this.token = '';
    this.displayForm = true;
    this.displaySuccess = false;
    this.displayError = false;
  }

  ngOnInit(): void {
    this.passresetForm = this._formBuilder.group({
      password: ['', [Validators.required]],
      cpassword: ['', [Validators.required]]
    });

    this._activatedRoute.queryParams
      .subscribe((params) => {
        this.email = params['email'] || '';
        this.token = params['token'] || '';
      });

    // Checking Email and Token exists
    if (this.email == '' || this.token == '') {
      this.displayError = true;
      this.displayForm = false;
    }

    // Password Validation set
    var myInput = document.getElementById("password-input") as HTMLInputElement;
    var letter = document.getElementById("pass-lower");
    var capital = document.getElementById("pass-upper");
    var number = document.getElementById("pass-number");
    var length = document.getElementById("pass-length");

    // When the user clicks on the password field, show the message box
    myInput.onfocus = function () {
      let input = document.getElementById("password-contain") as HTMLElement;
      input.style.display = "block"
    };

    // When the user clicks outside of the password field, hide the password-contain box
    myInput.onblur = function () {
      let input = document.getElementById("password-contain") as HTMLElement;
      input.style.display = "none"
    };

    // When the user starts to type something inside the password field
    myInput.onkeyup = function () {
      // Validate lowercase letters
      var lowerCaseLetters = /[a-z]/g;
      if (myInput.value.match(lowerCaseLetters)) {
        letter?.classList.remove("invalid");
        letter?.classList.add("valid");
      } else {
        letter?.classList.remove("valid");
        letter?.classList.add("invalid");
      }

      // Validate capital letters
      var upperCaseLetters = /[A-Z]/g;
      if (myInput.value.match(upperCaseLetters)) {
        capital?.classList.remove("invalid");
        capital?.classList.add("valid");
      } else {
        capital?.classList.remove("valid");
        capital?.classList.add("invalid");
      }

      // Validate numbers
      var numbers = /[0-9]/g;
      if (myInput.value.match(numbers)) {
        number?.classList.remove("invalid");
        number?.classList.add("valid");
      } else {
        number?.classList.remove("valid");
        number?.classList.add("invalid");
      }

      // Validate length
      if (myInput.value.length >= 8) {
        length?.classList.remove("invalid");
        length?.classList.add("valid");
      } else {
        length?.classList.remove("valid");
        length?.classList.add("invalid");
      }
    };

  }

  // convenience getter for easy access to form fields
  get f() { return this.passresetForm.controls; }

  /**
   * Form submit
   */
  onSubmit(): any {
    this.submitted = true;
    // stop here if form is invalid
    if (this.passresetForm.invalid) return;

    let formBody = this.passresetForm.getRawValue();
    let body = {
      Token: this.token,
      NewPassword: formBody.password,
      ConfirmPassword: formBody.cpassword
    };
    return this.httpService.POST(IdentityController.ResetPassword(this.email), body)
      .subscribe(() => {
        this.displayForm = false;
        this.displaySuccess = true;
      });
  }

  /**
   * Password Hide/Show
   */
  togglepasswordField() {
    this.passwordField = !this.passwordField;
  }

  /**
   * Password Hide/Show
   */
  toggleconfirmField() {
    this.confirmField = !this.confirmField;
  }

}

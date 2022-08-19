import { UsersValidator } from 'app/+users/validators/user.validator';
import { IdentityController } from 'app/+users/controllers/IdentityController';
import { BaseComponent } from '@shared/base/base.component';
import { UntypedFormBuilder, UntypedFormGroup } from '@angular/forms';
import { Component, Injector, OnInit } from '@angular/core';

@Component({
  selector: 'change-password',
  templateUrl: './change-password.component.html',
  styleUrls: ['./change-password.component.scss']
})


export class ChangePasswordComponent extends BaseComponent implements OnInit {

  updatePasswordSubmit: boolean = false;
  updatePasswordForm!: UntypedFormGroup;


  constructor
    (
      public override injector: Injector,
      private _formBuilder: UntypedFormBuilder
    ) {
    super(injector);
  }

  ngOnInit(): void {

    this.updatePasswordForm = this._formBuilder.group({
      currentPassword: ['', UsersValidator.password],
      newPassword: ['', UsersValidator.password],
      confirmPassword: ['', UsersValidator.confirmPassword]
    });

  }

  isInvalid(controllerName: string) {
    return this.updatePasswordForm.get(controllerName).errors && this.updatePasswordForm.get(controllerName).touched;
  }

  onPasswordSubmit() {
    this.updatePasswordSubmit = true;
    if (this.updatePasswordForm.invalid) {
      return;
    }
    let body = this.updatePasswordForm.getRawValue();
    this.httpService.PUT(IdentityController.changePassword, body)
      .subscribe(() => {
        this.notificationService.success("Success", "Bingo");
      })
  }


}

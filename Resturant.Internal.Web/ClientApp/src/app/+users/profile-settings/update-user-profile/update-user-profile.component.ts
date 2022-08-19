import { UsersValidator } from 'app/+users/validators/user.validator';
import { Router } from '@angular/router';
import { UsersController } from 'app/+users/controllers/UsersController';
import { UntypedFormBuilder, UntypedFormGroup, Validators, FormControl } from '@angular/forms';
import { Component, Injector, OnInit, Input } from '@angular/core';
import { BaseComponent } from '@shared/base/base.component';
import { CountriesDropdownDto } from 'app/+users/models/countriesDropdownDto';
import { SettingsController } from 'app/+users/controllers';

@Component({
  selector: 'update-user-profile',
  templateUrl: './update-user-profile.component.html',
  styleUrls: ['./update-user-profile.component.scss']
})

/**
 * Profile Settings Component
 */
export class UpdateUserProfileComponent extends BaseComponent implements OnInit {

  updateUserInfoSubmit: boolean = false;
  updateUserInfoForm!: UntypedFormGroup;
  currentUserEmail!: string;
  countries: CountriesDropdownDto[];
  @Input() image: File;

  constructor
  (
      public override injector: Injector,
      private _formBuilder: UntypedFormBuilder,
      private _router: Router
  ) {
    super(injector);
  }

  ngOnInit(): void {
    this.httpService.GET(SettingsController.getCountriesDropdown)
        .subscribe((countries) => {
          this.countries = countries;
        });
    this.currentUserEmail = this.currentUser.email;

    this.updateUserInfoForm = this._formBuilder.group({
      firstName: new FormControl(this.currentUser.firstName, UsersValidator.firstName),
      lastName: [this.currentUser.lastName, UsersValidator.lastName],
      phoneNumber: [this.currentUser.phoneNumber, UsersValidator.phoneNumber],
      country: [],
      city: [''],
      streetNumber: [''],
      zipCode: [''],
      image: [this.image]
    });

  }

  isInvalid(controllerName: string){
    return this.updateUserInfoForm.get(controllerName).errors && this.updateUserInfoForm.get(controllerName).touched;
  }


  onUserInfoSubmit() {
    this.updateUserInfoSubmit = true;
    if (this.updateUserInfoForm.invalid) {
      return;
    }
    console.log(this.image);

    let body = this.updateUserInfoForm.getRawValue();
    this.httpService.PUT(UsersController.UpdateUser, body, undefined)
        .subscribe(() => {
          this.notificationService.success("Success", "Bingo");
          this._router.navigate(['/users/profile']);
        })
  }

}

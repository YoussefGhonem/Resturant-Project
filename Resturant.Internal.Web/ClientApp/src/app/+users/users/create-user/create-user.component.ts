import { takeUntil } from 'rxjs/operators';
import { Component, Injector, Input, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup } from '@angular/forms';
import { NgbActiveModal } from '@ng-bootstrap/ng-bootstrap';
import { BaseComponent } from '@shared/base/base.component';
import { UsersController } from 'app/+users/controllers/UsersController';
import { UserRolesEnum } from 'app/+users/models/index';

@Component({
  selector: 'app-create-user',
  templateUrl: './create-user.component.html',
  styleUrls: ['./create-user.component.scss']
})
export class CreateUserComponent extends BaseComponent implements OnInit {
  form!: FormGroup;
  userRolesEnum = UserRolesEnum;
  constructor(public override injector: Injector, public modalService: NgbActiveModal,
    private formBuilder: FormBuilder) {
    super(injector);
  }

  ngOnInit(): void {
    this.initForm();
  }

  private initForm(): void {
    this.form = this.formBuilder.group({
      firstName: new FormControl(null),
      lastName: new FormControl(null),
      phone: new FormControl(null),
      email: new FormControl(null),
      role: new FormControl(null),
    });

  }

  getUrl(): string {
    let role = this.form.getRawValue().role;

    if (role == this.userRolesEnum.Vendor) {
      return UsersController.CreateVendor
    }
    if (role == this.userRolesEnum.CommitteeMember) {
      return UsersController.CreateCommiteeMember
    }
    else {
      return UsersController.CreateLocalAdmin
    }
  }

  submit() {
    let body = this.form.getRawValue();

    this.httpService.POST(this.getUrl(), body)
      .pipe(takeUntil(this.ngUnsubscribe))
      .subscribe(res => {
        this.modalService.close(true);
        this.notificationService.success('Exclude Profile', 'Your changes successfully updated! 🎉');
      });
  }

}

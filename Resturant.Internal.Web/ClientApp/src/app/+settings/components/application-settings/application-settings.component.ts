import { takeUntil } from 'rxjs/operators';
import { SettingsController } from '../../../+users/controllers/SettingsController';
import { BaseComponent } from '@shared/base/base.component';
import { Component, Injector } from '@angular/core';
import { UntypedFormBuilder, UntypedFormGroup, Validators } from '@angular/forms';


@Component({
  selector: 'app-settings',
  templateUrl: './application-settings.component.html',
  styleUrls: ['./application-settings.component.css']
})
export class ApplicationSettingsComponent extends BaseComponent {
  settings: any;
  // bread crumb items
  breadCrumbItems!: Array<{}>;

  constructor(
    public override injector: Injector,
    private _formBuilder: UntypedFormBuilder
  ) {
    super(injector);
  }

  ngOnInit(): void {

    this.breadCrumbItems = [
      { label: 'Home' },
      { label: 'Settings', active: true }
    ];

    this.getDetails();
  }

  getDetails() {
    this.httpService.GET(SettingsController.Details)
      .pipe(takeUntil(this.ngUnsubscribe))
      .subscribe(res => {
        this.settings = res;
        console.log(this.settings);
      });
  }

}

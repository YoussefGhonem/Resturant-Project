import { takeUntil } from 'rxjs/operators';
import { Component, Injector, Input, OnChanges, OnInit } from '@angular/core';
import { UntypedFormBuilder, UntypedFormGroup } from '@angular/forms';
import * as ClassicEditor from '@ckeditor/ckeditor5-build-classic';
import { BaseComponent } from '@shared/base/base.component';
import { SettingsController } from 'app/+users/controllers';
import { SettingsValidator } from 'app/+settings/validators/setting.validator';

@Component({
  selector: 'about-us',
  templateUrl: './about-us.component.html',
  styleUrls: ['./about-us.component.scss']
})
export class AboutUsComponent extends BaseComponent implements OnInit, OnChanges {
  public UserEditor = ClassicEditor;
  form!: UntypedFormGroup;
  @Input('settings') settings: any;

  editorConfig = {
    removePlugins: ['CKFinderUploadAdapter', 'CKFinder', 'EasyImage', 'Image', 'ImageCaption', 'ImageStyle', 'ImageToolbar', 'ImageUpload'],
    removeButtons: ['Image']
  };

  constructor(
    public override injector: Injector,
    private _formBuilder: UntypedFormBuilder
  ) {
    super(injector);
  }

  ngOnChanges(): void {
    this.initForm();
    this.form.patchValue(this.settings);
    console.log("settings", this.settings);

  }
  ngOnInit(): void {
  }

  initForm() {
    this.form = this._formBuilder.group({
      aboutUs: [null, SettingsValidator.aboutUs],
      emailService: [null, SettingsValidator.emailService],
      numberService: [null, SettingsValidator.numberService],
      workWithUsDescription: [null, SettingsValidator.workWithUsDescription],
    });
  }

  isInvalid(controllerName: string) {
    return this.form.get(controllerName).errors && this.form.get(controllerName).touched;
  }

  submit() {
    let body = this.form.getRawValue();
    this.httpService.PUT(SettingsController.UpdateAboutUsSettings, body)
      .pipe(takeUntil(this.ngUnsubscribe))
      .subscribe(res => {
        this.notificationService.success('Setings Update', 'Your changes successfully updated! 🎉');
      });
  }
}

import { Component, Injector, Input, OnInit, OnChanges } from '@angular/core';
import { UntypedFormBuilder, UntypedFormGroup, FormControl } from '@angular/forms';
import * as ClassicEditor from '@ckeditor/ckeditor5-build-classic';
import { BaseComponent } from '@shared/base/base.component';
import { SettingsValidator } from 'app/+settings/validators/setting.validator';
import { SettingsController } from 'app/+users/controllers';

@Component({
  selector: 'private-dining',
  templateUrl: './private-dining.component.html',
  styleUrls: ['./private-dining.component.scss']
})
export class PrivateDiningComponent extends BaseComponent implements OnInit, OnChanges {
  public UserEditor = ClassicEditor;
  form: UntypedFormGroup;
  @Input('settings') settings: any;

  editorConfig = {
    removePlugins: ['CKFinderUploadAdapter', 'CKFinder', 'EasyImage', 'Image', 'ImageCaption', 'ImageStyle', 'ImageToolbar', 'ImageUpload'],
    removeButtons: ['Image']
  };

  constructor(public override injector: Injector, private _formBuilder: UntypedFormBuilder) {
    super(injector);
  }
  ngOnChanges(): void {
    console.log("settings", this.settings);

  }
  ngOnInit(): void {
    this.initForm();
    this.form.patchValue(this.settings);
    console.log("settings", this.settings);

  }

  initForm() {
    this.form = this._formBuilder.group({
      document: new FormControl(null, SettingsValidator.document),
      privateDiningDescription: new FormControl(null, SettingsValidator.privateDiningDescription),
    });
  }

  isInvalid(controllerName: string) {
    return this.form.get(controllerName).errors && this.form.get(controllerName).touched;
  }
  onChange(event) {
    const file = event.target.files[0] as File;
    if (file == null) return;
    this.form.controls['document'].patchValue(file);
  }
  submit() {
    let body = this.form.getRawValue();
    this.httpService.PUT(SettingsController.UpdatePrivateDining, this.httpService.objectToFormData(body))
      .subscribe(() => {
        this.notificationService.success("Success", "Bingo!!!");
      });
  }
}

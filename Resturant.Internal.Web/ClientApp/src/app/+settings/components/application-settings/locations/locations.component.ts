import { get } from 'jquery';
import { takeUntil } from 'rxjs/operators';
import { Component, Injector, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup } from '@angular/forms';
import { NgbActiveModal } from '@ng-bootstrap/ng-bootstrap';
import { BaseComponent } from '@shared/base/base.component';
import { Validators } from 'angular-reactive-validation';
import { SettingsController } from 'app/+users/controllers';
import * as ClassicEditor from '@ckeditor/ckeditor5-build-classic';

@Component({
  selector: 'locations',
  templateUrl: './locations.component.html',
  styleUrls: ['./locations.component.scss']
})
export class LocationsComponent extends BaseComponent implements OnInit {
  form: FormGroup;
  locationDetails: any;
  public UserEditor = ClassicEditor;
  editorConfig = {
    removePlugins: ['CKFinderUploadAdapter', 'CKFinder', 'EasyImage', 'Image', 'ImageCaption', 'ImageStyle', 'ImageToolbar', 'ImageUpload'],
    removeButtons: ['Image']
  };

  constructor(public override injector: Injector, public modalService: NgbActiveModal,
    private formBuilder: FormBuilder) {
    super(injector);
  }

  ngOnInit(): void {
    this.loadData();
    this.initForm();
  }

  private initForm(): void {
    this.form = this.formBuilder.group({
      adress: new FormControl(null, { validators: [Validators.required('Title is required')] }),
      workDays: new FormControl(null, { validators: [Validators.required('Title is required')] }),
      googleMapLink: new FormControl(null, { validators: [Validators.required('Title is required')] }),
    });
  }

  isInvalid(controllerName: string): boolean {
    return this.form.get(controllerName).errors && this.form.touched;
  }

  onChange(event) {
    const file = event.target.files[0] as File;
    if (file == null) return;
    this.form.controls['image'].patchValue(file);
  }

  submit(): any {
    let body = this.form.getRawValue();
    this.httpService.PUT(SettingsController.UpdateLocations, body)
      .subscribe(() => {
        this.modalService.close(true);
        this.notificationService.success("Success", "Changes updated successfully");
      });
  }
  loadData() {
    this.httpService.GET(SettingsController.LocationDetails)
      .pipe(takeUntil(this.ngUnsubscribe))
      .subscribe(res => {
        this.locationDetails = res;
        this.form.patchValue(this.locationDetails)
        console.log(this.locationDetails);

      });
  }
}

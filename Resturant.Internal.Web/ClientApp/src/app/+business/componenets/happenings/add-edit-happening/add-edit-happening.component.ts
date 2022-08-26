import { Component, Injector, Input, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup } from '@angular/forms';
import { NgbActiveModal } from '@ng-bootstrap/ng-bootstrap';
import { BaseComponent } from '@shared/base/base.component';
import { Validators } from 'angular-reactive-validation';
import { BusinessController } from 'app/+business/controllers/BusinessController';
import * as ClassicEditor from '@ckeditor/ckeditor5-build-classic';

@Component({
  selector: 'add-edit-happening',
  templateUrl: './add-edit-happening.component.html',
  styleUrls: ['./add-edit-happening.component.scss']
})
export class AddEditHappeningComponent extends BaseComponent implements OnInit {
  @Input() mode: string = 'add'
  @Input() data: any;

  form: FormGroup;
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
    this.initForm();
  }

  private initForm(): void {
    this.form = this.formBuilder.group({
      title: new FormControl(null, { validators: [Validators.required('Title is required')] }),
      description: new FormControl(null, { validators: [Validators.required('Title is required')] }),
      image: new FormControl(null, { validators: [Validators.required('Title is required')] }),
    });

    if (this.mode == 'update')
      this.form.patchValue(this.data)
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

    if (this.mode != 'update')
      return this.httpService.POST(BusinessController.CreateHappening, this.httpService.objectToFormData(body))
        .subscribe(() => {
          this.modalService.close(true);
          this.notificationService.success("Success", "Changes updated successfully");
        });

    else
      return this.httpService.PUT(BusinessController.UpdateHappening, this.httpService.objectToFormData(body))
        .subscribe(() => {
          this.modalService.close(true);
          this.notificationService.success("Success", "Changes updated successfully");
        });
  }

}

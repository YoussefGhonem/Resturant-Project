import { Component, Injector, Input, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup } from '@angular/forms';
import { NgbActiveModal } from '@ng-bootstrap/ng-bootstrap';
import { BaseComponent } from '@shared/base/base.component';
import { filesService } from '@shared/services/files.service';
import { Validators } from 'angular-reactive-validation';
import { BusinessController } from 'app/+business/controllers/BusinessController';

@Component({
  selector: 'app-update-category-modal',
  templateUrl: './update-category-modal.component.html',
  styleUrls: ['./update-category-modal.component.scss']
})
export class UpdateCategoryModalComponent extends BaseComponent implements OnInit {
  @Input() categoryDetails: any;
  form: FormGroup;
  constructor(private formBuilder: FormBuilder, public override injector: Injector, private filesService: filesService, public modalService: NgbActiveModal) {
    super(injector);
  }

  ngOnInit(): void {
    this.initForm();
    this.form.patchValue(this.categoryDetails)
  }
  private initForm(): void {
    this.form = this.formBuilder.group({
      name: new FormControl(null, { validators: [Validators.required('this is required')] }),
      workDayes: new FormControl(null, { validators: [Validators.required('this is required')] }),
      file: new FormControl(null),
      description: new FormControl(null),
    });
  }
  isInvalid(controllerName: string): boolean {
    return this.form.get(controllerName).errors && this.form.touched;
  }

  onChange(event) {
    const file = event.target.files[0] as File;
    if (file == null || !this.filesService.isValidPDFExtension(file)) {
      return;
    }
    this.form.controls['file'].patchValue(file);
  }
  submit(): any {
    let body = this.form.getRawValue();
    console.log("body=>>>", body);

    this.httpService.PUT(BusinessController.UpdateCategory(this.categoryDetails.id), this.httpService.objectToFormData(body))
      .subscribe(() => {
        this.modalService.close(true)
        this.notificationService.success("Success", "Changes updated successfully");
      });
  }
}

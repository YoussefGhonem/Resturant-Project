import { Component, Injector, Input, OnInit } from '@angular/core';
import { FormArray, FormBuilder, FormControl, FormGroup } from '@angular/forms';
import { Router } from '@angular/router';
import { BaseComponent } from '@shared/base/base.component';
import { Validators } from 'angular-reactive-validation';
import { BusinessController } from 'app/+business/controllers/BusinessController';
import { get } from 'jquery';
import { forEach } from 'lodash';

@Component({
  selector: 'create-subcategory',
  templateUrl: './create-subcategory.component.html',
  styleUrls: ['./create-subcategory.component.scss']
})
export class CreateSubcategoryComponent extends BaseComponent implements OnInit {
  data = [];
  @Input('form') form: FormGroup;
  subCategoryForm: FormGroup;
  basicform: FormGroup;
  pageNumber = 1;
  pageSize = 5;

  constructor(public override injector: Injector, private router: Router,
    private formBuilder: FormBuilder) {
    super(injector);

  }
  ngOnInit(): void {
    this.initForm()
  }

  private initForm(): void {
    this.subCategoryForm = this.formBuilder.group({
      name: new FormControl(null, { validators: [Validators.required('this is required')] }),
      description: new FormControl(null, { validators: [Validators.required('this is required')] }),
      price: new FormControl(null, { validators: [Validators.required('this is required')] }),
    });
    this.basicform = this.formBuilder.group({
      name: new FormControl(null, { validators: [Validators.required('this is required')] }),
      description: new FormControl(null, { validators: [Validators.required('this is required')] }),
    });
  }

  isInvalid(controllerName: string): boolean {
    return this.basicform.get(controllerName).errors && this.form.touched;
  }

  isInvalidsubCatogries(controllerName: string): boolean {
    return this.subCategoryForm.get(controllerName).errors && this.form.touched;
  }

  addMore() {
    let name = this.subCategoryForm.getRawValue().name
    let description = this.subCategoryForm.getRawValue().description
    let price = this.subCategoryForm.getRawValue().price

    this.data?.push({
      name: name,
      description: description,
      price: price,
    })
    this.subCategoryForm.reset()
  }

  delete(index: any) {
    this.data.splice(index, 1);
  }

  patchForm() {
    let name = this.basicform.getRawValue().name
    let description = this.basicform.getRawValue().description
    this.form.patchValue({ subCatogries: { name: name, description: description, mealNames: this.data } });

    console.log("this.form.controls['subCatogries'].get('mealNames')", this.form);
    this.submit()
  }

  submit(): any {
    let body = this.form.getRawValue();
    console.log("body=>>>", body);

    this.httpService.POST(BusinessController.CreateMenu, this.httpService.objectToFormData(body))
      .subscribe(() => {
        this.notificationService.success("Success", "Changes updated successfully");
      });
  }

}

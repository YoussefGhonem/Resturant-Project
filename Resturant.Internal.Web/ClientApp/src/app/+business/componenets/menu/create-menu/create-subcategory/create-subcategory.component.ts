import { Component, Input, OnInit } from '@angular/core';
import { FormArray, FormBuilder, FormControl, FormGroup } from '@angular/forms';
import { Validators } from 'angular-reactive-validation';
import { get } from 'jquery';

@Component({
  selector: 'create-subcategory',
  templateUrl: './create-subcategory.component.html',
  styleUrls: ['./create-subcategory.component.scss']
})
export class CreateSubcategoryComponent implements OnInit {
  data = [];
  @Input('form') form: FormGroup;
  subCategoryForm: FormGroup;
  pageNumber = 1;
  pageSize = 5;

  constructor(private formBuilder: FormBuilder) { }

  ngOnInit(): void {
    this.initForm()
  }

  private initForm(): void {
    this.subCategoryForm = this.formBuilder.group({
      name: new FormControl(null, { validators: [Validators.required('this is required')] }),
      description: new FormControl(null, { validators: [Validators.required('this is required')] }),
      price: new FormControl(null, { validators: [Validators.required('this is required')] }),
    });
  }

  get subCatogries() {
    return this.form.controls["subCatogries"] as FormArray;
  }

  isInvalid(controllerName: string): boolean {
    return this.form.get(controllerName).errors && this.form.touched;
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

}

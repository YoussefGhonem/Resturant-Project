import { Component, Injector, Input, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup } from '@angular/forms';
import { NgbActiveModal } from '@ng-bootstrap/ng-bootstrap';
import { BaseComponent } from '@shared/base/base.component';
import { Validators } from 'angular-reactive-validation';
import { BusinessController } from 'app/+business/controllers/BusinessController';

@Component({
  selector: 'app-create-subcategory-modal',
  templateUrl: './create-subcategory-modal.component.html',
  styleUrls: ['./create-subcategory-modal.component.scss']
})
export class CreateSubcategoryModalComponent extends BaseComponent implements OnInit {

  @Input('categoryDetails') categoryDetails?: any;
  subCategoryForm: FormGroup;
  basicform: FormGroup;
  form: FormGroup;
  data = [];
  pageNumber = 1;
  pageSize = 5;

  constructor(public override injector: Injector, public modalService: NgbActiveModal,
    private formBuilder: FormBuilder) {
    super(injector);
  }

  ngOnInit(): void {
    this.initForm();
  }

  private initForm(): void {
    this.form = this.formBuilder.group({
      subCatogries: [],
    });

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
  }

  submit(): any {
    this.patchForm()
    let body = this.form.getRawValue();
    console.log("body=>>>", body);

    this.httpService.PUT(BusinessController.UpdateSubCategory(this.categoryDetails.id), body)
      .subscribe(() => {
        this.modalService.close(true)
        this.notificationService.success("Success", "Changes updated successfully");
      });
  }


}

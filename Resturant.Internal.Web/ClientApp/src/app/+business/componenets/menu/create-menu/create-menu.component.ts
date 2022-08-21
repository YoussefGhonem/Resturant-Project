import { Component, Injector, OnInit } from '@angular/core';
import { FormArray, FormBuilder, FormControl, FormGroup } from '@angular/forms';
import { BaseComponent } from '@shared/base/base.component';
import { Validators } from 'angular-reactive-validation';
import { BusinessController } from 'app/+business/controllers/BusinessController';

@Component({
  selector: 'app-create-menu',
  templateUrl: './create-menu.component.html',
  styleUrls: ['./create-menu.component.scss']
})
export class CreateMenuComponent extends BaseComponent implements OnInit {
  form: FormGroup;

  constructor(public override injector: Injector,
    private formBuilder: FormBuilder) {
    super(injector);

  }


  ngOnInit(): void {
    this.initForm();

  }

  get subCatogries() {
    return this.form.controls["subCatogries"] as FormArray;
  }


  private initForm(): void {
    this.form = this.formBuilder.group({
      name: new FormControl(null, { validators: [Validators.required('this is required')] }),
      workDayes: new FormControl(null, { validators: [Validators.required('this is required')] }),
      file: new FormControl(null, { validators: [Validators.required('this is required')] }),
      description: new FormControl(null),

      subCatogries: this.formBuilder.group({
        name: new FormControl(null, { validators: [Validators.required('this is required')] }),
        description: new FormControl(null, { validators: [Validators.required('this is required')] }),

        mealNames: this.formBuilder.group({
          name: new FormControl(null, { validators: [Validators.required('this is required')] }),
          description: new FormControl(null, { validators: [Validators.required('this is required')] }),
          price: new FormControl(null, { validators: [Validators.required('this is required')] }),
        }),
      }),
    });
  }

  addSubCatogry(item?: any) {
    const subCatogryForm = this.formBuilder.group({
      mealNames: this.formBuilder.group({
        name: new FormControl(item?.name, { validators: [Validators.required('this is required')] }),
        description: new FormControl(item?.description, { validators: [Validators.required('this is required')] }),
        price: new FormControl(item.price, { validators: [Validators.required('this is required')] }),
      }),
    });

    this.subCatogries.push(subCatogryForm);
  }

  deleteVessel(index: number) {
    this.subCatogries.removeAt(index);
  }

  isInvalid(controllerName: string): boolean {
    return this.form.get(controllerName).errors && this.form.touched;
  }

  onChange(event) {
    const file = event.target.files[0] as File;
    if (file == null) return;
    this.form.controls['file'].patchValue(file);
  }

  submit(): any {
    let body = this.form.getRawValue();
    this.httpService.POST(BusinessController.CreateManu, this.httpService.objectToFormData(body))
      .subscribe(() => {
        this.notificationService.success("Success", "Changes updated successfully");
      });
  }
}

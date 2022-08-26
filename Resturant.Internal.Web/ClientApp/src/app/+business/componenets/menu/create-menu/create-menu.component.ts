import { Component, Injector, OnInit } from '@angular/core';
import { FormArray, FormBuilder, FormControl, FormGroup } from '@angular/forms';
import { Router } from '@angular/router';
import { BaseComponent } from '@shared/base/base.component';
import { Validators } from 'angular-reactive-validation';

@Component({
  selector: 'app-create-menu',
  templateUrl: './create-menu.component.html',
  styleUrls: ['./create-menu.component.scss']
})
export class CreateMenuComponent extends BaseComponent implements OnInit {
  form: FormGroup;

  constructor(public override injector: Injector, private router: Router,
    private formBuilder: FormBuilder) {
    super(injector);

  }
  ngOnInit(): void {
    this.initForm();
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
    if (file == null) return;
    this.form.controls['file'].patchValue(file);
  }

  createNew() {
    let currentUrl = this.router.url;
    this.router.navigateByUrl('/', { skipLocationChange: true }).then(() => {
      this.router.navigate([currentUrl]);
    });

  }
}

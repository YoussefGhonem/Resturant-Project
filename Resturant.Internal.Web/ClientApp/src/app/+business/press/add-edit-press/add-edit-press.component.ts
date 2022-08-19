import { takeUntil } from 'rxjs/operators';
import { Component, Injector, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup } from '@angular/forms';
import { NgbActiveModal } from '@ng-bootstrap/ng-bootstrap';
import { BaseComponent } from '@shared/base/base.component';
import { PressController } from 'app/+settings/controllers/PressController';
import { Validators } from 'angular-reactive-validation';

@Component({
  selector: 'app-add-edit-press',
  templateUrl: './add-edit-press.component.html',
  styleUrls: ['./add-edit-press.component.scss']
})
export class AddEditPressComponent extends BaseComponent implements OnInit {
  form: FormGroup;

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
      hyperLink: new FormControl(null, { validators: [Validators.required('Title is required')] }),
      image: new FormControl(null, { validators: [Validators.required('Title is required')] }),
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
    this.httpService.POST(PressController.Create, this.httpService.objectToFormData(body))
      .subscribe(() => {
        this.modalService.close(true);
        this.notificationService.success("Success", "Changes updated successfully");
      });
  }
}

import { takeUntil } from 'rxjs/operators';
import { Component, Injector, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup } from '@angular/forms';
import { NgbActiveModal } from '@ng-bootstrap/ng-bootstrap';
import { BaseComponent } from '@shared/base/base.component';
import { PressController } from 'app/+settings/controllers/PressController';

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
      title: new FormControl(null,),
      description: new FormControl(null,),
      hyperLink: new FormControl(null,),
      image: new FormControl(null,),
    });
  }

  isInvalid(controllerName: string): boolean {
    return this.form.get(controllerName).errors && this.form.touched;
  }


  submit(): any {
    let body = this.form.getRawValue();
    this.httpService.POST(PressController.Create, body)
      .pipe(takeUntil(this.ngUnsubscribe))
      .subscribe(res => {
        this.modalService.close(true);
        this.notificationService.success('Create User', 'Your changes successfully updated! 🎉');
      });
  }

}

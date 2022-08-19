import { takeUntil } from 'rxjs/operators';
import { Component, Injector, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup } from '@angular/forms';
import { NgbActiveModal } from '@ng-bootstrap/ng-bootstrap';
import { BaseComponent } from '@shared/base/base.component';
import { SettingsController } from 'app/+users/controllers';
import { Validators } from "angular-reactive-validation";

@Component({
  selector: 'app-add-gallery',
  templateUrl: './add-gallery.component.html',
  styleUrls: ['./add-gallery.component.scss']
})
export class AddGalleryComponent extends BaseComponent implements OnInit {
  form: FormGroup;
  filenames: any[] = [];

  constructor(public override injector: Injector, public modalService: NgbActiveModal,
    private formBuilder: FormBuilder) {
    super(injector);

  }

  ngOnInit(): void {
    this.initForm();

  }

  private initForm(): void {
    this.form = this.formBuilder.group({
      name: new FormControl(null, Validators.required('Name is required')),
      images: new FormControl(null, Validators.required('image is required')),
    });
  }

  isInvalid(controllerName: string): boolean {
    return this.form?.get(controllerName)?.errors && this.form.touched;
  }
  formData: FormData = new FormData();
  files: File[];

  onChange(event) {
    this.files = event.target.files;
    if (this.files.length == 0) return;

    [...this.files].forEach(file => {
      this.filenames.push(file.name)
    });

  }

  submit() {
    for (const file of this.files) {
      this.formData.append('images', file)
    }
    this.formData.append('name', this.form.getRawValue().name)

    console.log("this.form.getRawValue()", this.form.getRawValue());
    this.httpService.POST(SettingsController.CreateGallery, this.formData)
      .subscribe(() => {
        this.modalService.close(true);
        this.notificationService.success("Success", "Bingo!!!");
      });

  }

}

import { FormGroup } from '@angular/forms';
import { Component, Input, OnInit } from '@angular/core';
import { filesService } from '@shared/services/files.service';

@Component({
  selector: 'create-category',
  templateUrl: './create-category.component.html',
  styleUrls: ['./create-category.component.scss']
})
export class CreateCategoryComponent implements OnInit {
  @Input('form') form: FormGroup;
  constructor(private filesService: filesService) { }

  ngOnInit(): void {
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
}

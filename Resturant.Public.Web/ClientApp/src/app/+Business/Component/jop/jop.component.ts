import { Component, Injector, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, UntypedFormBuilder } from '@angular/forms';
import { BaseComponent } from '@shared/base/base.component';
import { Validators } from 'angular-reactive-validation';
import { BusinessController } from 'app/+Business/Controllers/Business';
import { takeUntil, debounceTime } from 'rxjs/operators';
@Component({
  selector: 'app-jop',
  templateUrl: './jop.component.html',
  styleUrls: ['./jop.component.css']
})
export class JopComponent extends BaseComponent implements OnInit {
JopForm: FormGroup;
constructor(private _formBuilder: UntypedFormBuilder,public override injector: Injector) { 
  super(injector);

  this.JopForm=this._formBuilder.group({
    Name:new FormControl('',[Validators.required,Validators.minLength(2)]),
    Email:new FormControl('',[Validators.required,Validators.email]),
    PhoneNumber:new FormControl('',[Validators.required,Validators.minLength(3)]),
    CoverLatter:new FormControl('',[Validators.required,Validators.minLength(5)]),
    Attachment: new FormControl('', [Validators.required])
  });

}

  ngOnInit(): void {
  }
  // If File Field Changes
  onFileChange(event) {
    if (event.target.files.length > 0) {
      const file = event.target.files[0];
      this.JopForm.patchValue({
        Attachment: file
      });
    }
  }

  // On Apply Button
  submit(){
    if (this.JopForm.valid) {
      const formData = new FormData();
      formData.append('Attachment', this.JopForm.get('Attachment').value);
      formData.append('Email', this.JopForm.get('Email').value);
      formData.append('PhoneNumber', this.JopForm.get('PhoneNumber').value);
      formData.append('CoverLatter', this.JopForm.get('CoverLatter').value);
      formData.append('Name', this.JopForm.get('Name').value);
      this.httpService.POST(BusinessController.PostJop,formData).subscribe({
        next:()=>{
          this.notificationService.success("Success", "Applying For Jop");
          this.JopForm.reset();
        },
        error:()=>{this.notificationService.error("Error", "Applying For Jop");}
      });
    }
  }

}

import { Component, Injector, OnInit } from '@angular/core';
import { FormControl, FormGroup, UntypedFormBuilder, Validators } from '@angular/forms';
import { BaseComponent } from '@shared/base/base.component';
import { BusinessController } from 'app/+Business/Controllers/Business';

@Component({
  selector: 'app-contact',
  templateUrl: './contact.component.html',
  styleUrls: ['./contact.component.css']
})
export class ContactComponent extends BaseComponent implements OnInit {

  ContactForm:FormGroup;
  constructor(private _formBuilder: UntypedFormBuilder,public override injector: Injector) { 
    super(injector);
  
    this.ContactForm=this._formBuilder.group({
      name:new FormControl('',[Validators.required,Validators.minLength(2)]),
      email:new FormControl('',[Validators.required,Validators.email]),
      phoneNumber:new FormControl('',[Validators.required,Validators.minLength(3)]),
      massage:new FormControl('',[Validators.required,Validators.minLength(5)]),
      touchAbout: new FormControl('', [Validators.required]),
    });
  }
  ngOnInit(): void {
   
  }

  submit(){
    if (this.ContactForm.valid) {
      this.httpService.POST(BusinessController.PostContactUs,this.ContactForm.value).subscribe({
        next:()=>{
          this.notificationService.success("Success", "We Receive Your Massage");
          this.ContactForm.reset();
        },
        error:()=>{this.notificationService.error("Error", "Your Massage Not Send");}
      });
    }
  }

}

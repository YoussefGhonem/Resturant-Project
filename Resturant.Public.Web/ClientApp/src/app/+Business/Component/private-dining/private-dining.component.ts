import { Component, Injector, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, UntypedFormBuilder, Validators } from '@angular/forms';
import { BaseComponent } from '@shared/base/base.component';
import { BusinessController } from 'app/+Business/Controllers/Business';
import { takeUntil, debounceTime } from 'rxjs/operators';
@Component({
  selector: 'app-private-dining',
  templateUrl: './private-dining.component.html',
  styleUrls: ['./private-dining.component.css']
})
export class PrivateDiningComponent extends BaseComponent implements OnInit {
  formPrivateDiningPagination!: FormGroup;
  PrivateDiningForm: FormGroup;
  pivateDiningDate: any[];
  SettingData: any=[];
  PrivateDiningImages:any=[];
  PrivateDiningImageChangeObject:any=[];
  total:number=0;
  body:any={};

  constructor(private _2formBuilder: FormBuilder,private _formBuilder: UntypedFormBuilder,public override injector: Injector) { 
    super(injector);
          // Form private Dining
      this.PrivateDiningForm=this._2formBuilder.group({
        firstName:new FormControl('',[Validators.required,Validators.minLength(2)]),
        lastName:new FormControl('',[Validators.required,Validators.minLength(2)]),
        phoneNumber:new FormControl('',[Validators.required,Validators.minLength(3)]),
        company:new FormControl('',[Validators.required,Validators.minLength(2)]),
        eventDate:new FormControl('',[Validators.required]),
        startTime: new FormControl('', [Validators.required]),
        endTime:new FormControl('',[Validators.required]),
        numberOfPeople:new FormControl('',[Validators.required]),
        additionalInformation:new FormControl('',[]),
        email: new FormControl('', [Validators.required,Validators.email])
      })
  }
  ngOnInit(): void {
    this.initSearchForm();
    this.loadData();
  }
  private initSearchForm(): void {
    this.formPrivateDiningPagination = this._formBuilder.group({
      // Pagination
      pageNumber: new FormControl(1),
      pageSize: new FormControl(20),
  });
  this.formPrivateDiningPagination.valueChanges
  .pipe(debounceTime(500))
  .subscribe(res => {
    this.formPrivateDiningPagination?.controls['pageNumber'].patchValue(1, { emitEvent: false });
    this.loadData();
  });

}

pageChange(pageNumber: number) {
  this.formPrivateDiningPagination.controls['pageNumber'].patchValue(pageNumber, { emitEvent: false });
  this.loadData();
}



  loadData() {
    let filterPrivateDiningImage=this.formPrivateDiningPagination.getRawValue();
    this.httpService.GET(BusinessController.Settings)
      .pipe(takeUntil(this.ngUnsubscribe))
      .subscribe(res => {
        this.SettingData = res;
        console.log(this.SettingData);
      });

      //Private Dining Get Data Images
      this.httpService.GET(BusinessController.PrivateDiningImages,filterPrivateDiningImage)
      .pipe(takeUntil(this.ngUnsubscribe))
      .subscribe(res => {
        
        this.total = res.total;
        this.PrivateDiningImages = res.data.map(item => {
          console.log(this.PrivateDiningImages.length);
          return {
            image: item.attachmentPath,
            thumbImage:item.attachmentPath,
            title: item.attachmentName,
            createdOn:item.createdOn
          };

        });
      });
  }

  // Open file Pdf
    openFile(fileName:any) {
      window.open(fileName);
    }

    // submit form 
    submit(){
      console.log(this.PrivateDiningForm.value);
      if (this.PrivateDiningForm.valid) {
        // const formData = new FormData();
        // formData.append('lastName', this.PrivateDiningForm.get('lastName').value);
        // formData.append('firstName', this.PrivateDiningForm.get('firstName').value);
        // formData.append('eventDate', this.PrivateDiningForm.get('eventDate').value);
        // formData.append('company', this.PrivateDiningForm.get('company').value);
        // formData.append('phoneNumber', this.PrivateDiningForm.get('phoneNumber').value);
        // formData.append('startTime', this.PrivateDiningForm.get('startTime').value);
        // formData.append('endTime', this.PrivateDiningForm.get('endTime').value);
        // formData.append('numberOfPeople', this.PrivateDiningForm.get('numberOfPeople').value);
        // formData.append('email', this.PrivateDiningForm.get('email').value);
        // formData.append('additionalInformation', this.PrivateDiningForm.get('additionalInformation').value);
        this.body=this.PrivateDiningForm.value;
        console.log(this.body);
        this.httpService.POST(BusinessController.PrivateDiningForm,this.body).subscribe({
          next:()=>{
            this.notificationService.success("Success", "Private Dining Submited ,We Will Contact with You As Soon As");
            this.PrivateDiningForm.reset();
            document.getElementById("Private-Dining").style.display="none";
          },
          error:()=>{this.notificationService.error("Error", "Private Dining Not Submited");}
        });
      }else{
        this.notificationService.error("Form Not Valid","Check Value Of Form")
      }     
    }

}


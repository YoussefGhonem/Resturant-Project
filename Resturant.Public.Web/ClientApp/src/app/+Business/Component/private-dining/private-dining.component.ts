import { Component, Injector, OnInit } from '@angular/core';
import { FormControl, FormGroup, UntypedFormBuilder, Validators } from '@angular/forms';
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

  constructor(private _formBuilder: UntypedFormBuilder,public override injector: Injector) { 
    super(injector);
  }
  ngOnInit(): void {
    this.initSearchForm();
    this.loadData();

    // Form private Dining
    this.PrivateDiningForm=this._formBuilder.group({
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
        this.PrivateDiningImages = res.data.map(item => {
          return {
            image: item.attachmentPath,
            thumbImage:item.attachmentPath,
            title: item.attachmentName,
            createdOn:item.createdOn
          };
        });;
        this.total = res.total;
      });
  }

  // Open file Pdf
    openFile(fileName:any) {
      window.open(fileName);
    }

    // submit form 
    submit(){
      console.log(this.PrivateDiningForm.value);
      this.httpService.POST(BusinessController.PrivateDiningForm,this.PrivateDiningForm.value).subscribe({
        next:()=>{
          this.notificationService.success("Success", "Private Dining Submited ,We Will Contact with You As Soon As");
          this.PrivateDiningForm.reset();
          document.getElementById("Private-Dining").style.display="none";
        },
        error:()=>{this.notificationService.error("Error", "Private Dining Not Submited");}
      });
    }

}

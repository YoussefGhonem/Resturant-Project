import { Component, Injector, OnInit } from '@angular/core';
import { FormControl, FormGroup, UntypedFormBuilder } from '@angular/forms';
import { NgbSlideEvent, NgbSlideEventSource } from '@ng-bootstrap/ng-bootstrap';
import { BaseComponent } from '@shared/base/base.component';
import { BusinessController } from 'app/+Business/Controllers/Business';
import { takeUntil, debounceTime } from 'rxjs/operators';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss']
})
export class HomeComponent extends BaseComponent implements OnInit {
  form!: FormGroup;
  formGallery!: FormGroup;
  data: any[];
  WhyUsData:any[];
  Gallery:any[];
  total: number = 0;
  totalGallery:number=0;
  event_list:any=true;
  constructor(private _formBuilder: UntypedFormBuilder,private _formBuilderGallery: UntypedFormBuilder,public override injector: Injector) { 
    super(injector);
  }

  ngOnInit(): void {
    this.initSearchForm();
    this.loadData();
  }
  ngAfterViewInit(){

  }
  private initSearchForm(): void {
    this.form = this._formBuilder.group({
      // Pagination
      pageNumber: new FormControl(1),
      pageSize: new FormControl(10),
  });
  this.formGallery = this._formBuilderGallery.group({
    // Pagination
    pageNumber: new FormControl(1),
    pageSize: new FormControl(8),
});
  this.form.valueChanges
  .pipe(debounceTime(500))
  .subscribe(res => {
    this.form?.controls['pageNumber'].patchValue(1, { emitEvent: false });
    this.loadData();
  });
  this.formGallery.valueChanges
  .pipe(debounceTime(500))
  .subscribe(res => {
    this.form?.controls['pageNumber'].patchValue(1, { emitEvent: false });
    this.loadData();
  });
  }
  pageChange(pageNumber: number) {
    this.form.controls['pageNumber'].patchValue(pageNumber, { emitEvent: false });
    this.loadData();
  }

  loadData() {
    let filters = this.form.getRawValue();
    let filterGalery=this.formGallery.getRawValue();
    console.log("filters", filters);
    this.httpService.GET(BusinessController.GetSeeting, filters)
      .pipe(takeUntil(this.ngUnsubscribe))
      .subscribe(res => {
        this.data = res.data;
        this.total = this.total;
        console.log(this.data);
      });
    this.httpService.GET(BusinessController.GetWhyUs).pipe(takeUntil(this.ngUnsubscribe))
    .subscribe(res => {
      this.WhyUsData = res;
      console.log(res);
    });
    this.httpService.GET(BusinessController.GetGallery,filterGalery).pipe(takeUntil(this.ngUnsubscribe))
    .subscribe(res => {
      this.Gallery = res.data;
      this.totalGallery = this.total;
      console.log(this.Gallery);
    });

  }


}

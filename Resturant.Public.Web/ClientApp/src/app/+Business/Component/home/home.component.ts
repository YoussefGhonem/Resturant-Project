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
  data: any[];
  total: number = 0;
  event_list:any=true;
  constructor(private _formBuilder: UntypedFormBuilder,public override injector: Injector) { 
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
  this.form.valueChanges
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
    console.log("filters", filters);
    this.httpService.GET(BusinessController.GetSeeting, filters)
      .pipe(takeUntil(this.ngUnsubscribe))
      .subscribe(res => {
        this.data = res.data;
        this.total = this.total;
        console.log(this.data);
      });
  }

}

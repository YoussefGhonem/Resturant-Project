import { OnChanges, SimpleChanges } from '@angular/core';
import { takeUntil, debounceTime } from 'rxjs/operators';
import { Component, Injector, Input, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup } from '@angular/forms';
import { NgbActiveModal, NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { BaseComponent } from '@shared/base/base.component';
import { UsersController } from 'app/+users/controllers/UsersController';

@Component({
  selector: 'vendors-list',
  templateUrl: './vendors.component.html',
  styleUrls: ['./vendors.component.scss']
})
export class VendorsComponent extends BaseComponent implements OnInit, OnChanges {
  vendors: any[] = [];
  form!: FormGroup;
  total: number = 0;

  @Input('filters') filters!: FormGroup;

  constructor(
    public modalService: NgbModal,
    public override injector: Injector,
    private _formBuilder: FormBuilder) {
    super(injector);
  }

  ngOnChanges(): void {
    this.filters.valueChanges.pipe(debounceTime(500))
      .subscribe(value => {
        this.form.patchValue(this.filters.getRawValue());
        this.form?.controls['pageNumber'].patchValue(1, { emitEvent: false });
        this.loadVendors();
      });
  }

  ngOnInit(): void {
    this.initSearchForm();
    this.loadVendors();
  }

  private initSearchForm(): void {
    this.form = this._formBuilder.group({
      // Pagination
      pageNumber: new FormControl(1),
      pageSize: new FormControl(10),
      // Filters
      name: new FormControl(''),
      isActive: new FormControl(),
      isVerified: new FormControl(),
    });

    // this.form.valueChanges
    //   .pipe(debounceTime(500))
    //   .subscribe(res => {
    //     this.form?.controls['pageNumber'].patchValue(1, { emitEvent: false });
    //     this.loadVendors();
    //   });
  }

  pageChange(pageNumber: number) {
    this.form.controls['pageNumber'].patchValue(pageNumber, { emitEvent: false });
    this.loadVendors();
  }

  private loadVendors() {
    let filters = this.form.getRawValue();
    console.log("filters", filters);

    this.httpService.GET(UsersController.Vendors, filters)
      .pipe(takeUntil(this.ngUnsubscribe))
      .subscribe(res => {
        this.vendors = res?.data;
        this.total = res?.total;
      });
  }

}

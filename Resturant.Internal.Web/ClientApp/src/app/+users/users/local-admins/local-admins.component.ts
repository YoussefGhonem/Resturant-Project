import { takeUntil, debounceTime } from 'rxjs/operators';
import { Component, Injector, Input, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup } from '@angular/forms';
import { NgbActiveModal, NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { BaseComponent } from '@shared/base/base.component';
import { UsersController } from 'app/+users/controllers/UsersController';
@Component({
  selector: 'local-admin-list',
  templateUrl: './local-admins.component.html',
  styleUrls: ['./local-admins.component.scss']
})
export class LocalAdminsComponent extends BaseComponent implements OnInit {
  localAdmins: any[] = [];
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
        this.form.controls['name'].patchValue(this.filters.getRawValue().name);
        this.form.controls['isActive'].patchValue(this.filters.getRawValue().isActive);
        this.form?.controls['pageNumber'].patchValue(1, { emitEvent: false });
        this.loadLocalAdmins();
      });
  }

  ngOnInit(): void {
    this.initSearchForm();
    this.loadLocalAdmins();
  }

  private initSearchForm(): void {
    this.form = this._formBuilder.group({
      // Pagination
      pageNumber: new FormControl(1),
      pageSize: new FormControl(10),
      // Filters
      name: new FormControl(''),
      isActive: new FormControl(''),
    });
  }

  pageChange(pageNumber: number) {
    this.form.controls['pageNumber'].patchValue(pageNumber, { emitEvent: false });
    this.loadLocalAdmins();
  }

  private loadLocalAdmins() {
    let filters = this.form.getRawValue();
    console.log("filters", filters);

    this.httpService.GET(UsersController.LocalAdmins, filters, true)
      .pipe(takeUntil(this.ngUnsubscribe))
      .subscribe(res => {
        this.localAdmins = res?.data;
        this.total = res?.total;
      });
  }

}

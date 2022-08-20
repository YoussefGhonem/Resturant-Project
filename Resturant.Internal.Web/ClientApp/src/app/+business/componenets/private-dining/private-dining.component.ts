import { takeUntil, debounceTime } from 'rxjs/operators';
import { Component, Injector, OnInit } from '@angular/core';
import { FormControl, FormGroup, UntypedFormBuilder } from '@angular/forms';
import { BaseComponent } from '@shared/base/base.component';
import { NgbActiveModal, NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { BusinessController } from 'app/+business/controllers/BusinessController';

@Component({
  selector: 'app-private-dining',
  templateUrl: './private-dining.component.html',
  styleUrls: ['./private-dining.component.scss']
})
export class PrivateDiningComponent extends BaseComponent implements OnInit {

  data: any[];
  total: number = 0;
  form!: FormGroup;
  breadCrumbItems!: Array<{}>;

  constructor(public activeModal: NgbActiveModal,
    public modalService: NgbModal, public override injector: Injector, private _formBuilder: UntypedFormBuilder) {
    super(injector);
  }
  ngOnInit(): void {
    this.breadCrumbItems = [
      { label: 'Home' },
      { label: 'Private Dining', active: true }
    ];
    this.initSearchForm()
    this.loadData()
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
    this.httpService.GET(BusinessController.PrivateDining, filters)
      .pipe(takeUntil(this.ngUnsubscribe))
      .subscribe(res => {
        this.data = res.data;
        this.total = this.total;
        console.log(this.data);
      });
  }
}

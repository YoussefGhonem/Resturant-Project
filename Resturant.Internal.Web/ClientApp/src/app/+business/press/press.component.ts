import { takeUntil, debounceTime } from 'rxjs/operators';
import { Component, Injector, OnInit } from '@angular/core';
import { FormControl, FormGroup, UntypedFormBuilder } from '@angular/forms';
import { BaseComponent } from '@shared/base/base.component';
import { SettingsController } from 'app/+users/controllers';
import { AddEditPressComponent } from './add-edit-press/add-edit-press.component';
import { ngbModalOptions } from '@shared/default-values';
import { NgbActiveModal, NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { PressController } from '../controllers/PressController';

@Component({
  selector: 'app-press',
  templateUrl: './press.component.html',
  styleUrls: ['./press.component.scss']
})
export class PressComponent extends BaseComponent implements OnInit {
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
      { label: 'Press', active: true }
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
    this.httpService.GET(PressController.GetAll, filters)
      .pipe(takeUntil(this.ngUnsubscribe))
      .subscribe(res => {
        this.data = res.data;
        this.total = this.total;
        console.log(this.data);
      });
  }

  create() {
    const modalRef = this.modalService.open(AddEditPressComponent, {
      ...ngbModalOptions,
      windowClass: 'modal modal-success',
      size: 'lg'
    });
    modalRef
      .result
      .then((actionCompleted: boolean) => !actionCompleted || this.activeModal.close(true) || this.loadData())
      .catch(() => {
      });
  }
}

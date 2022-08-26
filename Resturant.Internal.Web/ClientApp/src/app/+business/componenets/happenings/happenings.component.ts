import { AddEditHappeningComponent } from './add-edit-happening/add-edit-happening.component';
import { debounceTime, takeUntil } from 'rxjs/operators';
import { Component, Injector, OnInit } from '@angular/core';
import { FormControl, FormGroup, UntypedFormBuilder } from '@angular/forms';
import { NgbActiveModal, NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { BaseComponent } from '@shared/base/base.component';
import { BusinessController } from 'app/+business/controllers/BusinessController';
import { ngbModalOptions } from '@shared/default-values';

@Component({
  selector: 'app-happenings',
  templateUrl: './happenings.component.html',
  styleUrls: ['./happenings.component.scss']
})
export class HappeningsComponent extends BaseComponent implements OnInit {
  happenings: any[]
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
      { label: 'Happenings', active: true }
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
    this.httpService.GET(BusinessController.Happenings, filters)
      .pipe(takeUntil(this.ngUnsubscribe))
      .subscribe(res => {
        this.happenings = res.data;
        this.total = this.total;
        console.log(this.happenings);
      });
  }

  create() {
    const modalRef = this.modalService.open(AddEditHappeningComponent, {
      ...ngbModalOptions,
      windowClass: 'modal modal-success',
      size: 'xl'
    });
    modalRef
      .result
      .then((actionCompleted: boolean) => !actionCompleted || this.activeModal.close(true) || this.loadData())
      .catch(() => {
      });
  }
  Update(item: any) {
    const modalRef = this.modalService.open(AddEditHappeningComponent, {
      ...ngbModalOptions,
      windowClass: 'modal modal-success',
      size: 'xl'
    });
    modalRef.componentInstance.mode = 'update';
    modalRef.componentInstance.data = item;
    modalRef
      .result
      .then((actionCompleted: boolean) => !actionCompleted || this.activeModal.close(true) || this.loadData())
      .catch(() => {
      });
  }
}

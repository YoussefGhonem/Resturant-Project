import { debounceTime, takeUntil } from 'rxjs/operators';
import { Component, Injector, OnInit } from '@angular/core';
import { FormControl, FormGroup, UntypedFormBuilder } from '@angular/forms';
import { BaseComponent } from '@shared/base/base.component';
import { BusinessController } from 'app/+business/controllers/BusinessController';
import { NgbActiveModal, NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { AddEditPersonComponent } from './add-edit-person/add-edit-person.component';
import { ngbModalOptions } from '@shared/default-values';

@Component({
  selector: 'app-teams',
  templateUrl: './teams.component.html',
  styleUrls: ['./teams.component.scss']
})
export class TeamsComponent extends BaseComponent implements OnInit {
  persons: any[]
  breadCrumbItems!: Array<{}>;
  total: number = 0;
  form!: FormGroup;

  constructor(public activeModal: NgbActiveModal,
    public modalService: NgbModal, public override injector: Injector, private _formBuilder: UntypedFormBuilder) {
    super(injector);
  }

  ngOnInit(): void {
    this.breadCrumbItems = [
      { label: 'Home' },
      { label: 'our Teams', active: true }
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

  delete() {

  }

  create() {
    const modalRef = this.modalService.open(AddEditPersonComponent, {
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

  edit(item: any) {
    const modalRef = this.modalService.open(AddEditPersonComponent, {
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

  loadData() {
    let filters = this.form.getRawValue();
    this.httpService.GET(BusinessController.Teams, filters)
      .pipe(takeUntil(this.ngUnsubscribe))
      .subscribe(res => {
        this.persons = res.data;
        this.total = this.total;
      });
  }
}
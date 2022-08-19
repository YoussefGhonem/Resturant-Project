import { ActivateComponent } from '@shared/components/activate/activate.component';
import { Component, Injector, Input, OnChanges, OnInit } from '@angular/core';
import { debounceTime, takeUntil } from 'rxjs/operators';
import { FormBuilder, FormControl, FormGroup } from '@angular/forms';
import { NgbActiveModal, NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { BaseComponent } from '@shared/base/base.component';
import { DeleteComponent } from '@shared/components/delete/delete.component';
import { ngbModalOptions } from '@shared/default-values';
import { PublicUserController } from 'app/+users/controllers/index';
import { DeactivateComponent } from '@shared/components/deactivate/deactivate.component';

@Component({
  selector: 'public-user',
  templateUrl: './public-user.component.html',
  styleUrls: ['./public-user.component.css']
})
export class PublicUserComponent extends BaseComponent implements OnInit, OnChanges {
  publicUsers: any[] = [];
  form!: FormGroup;
  total: number = 0;

  @Input('filters') filters!: FormGroup;

  constructor(
    public activeModal: NgbActiveModal,
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
        this.loadPublicUsers();
      });
  }

  ngOnInit(): void {
    this.initSearchForm();
    this.loadPublicUsers();
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
  }

  pageChange(pageNumber: number) {
    this.form.controls['pageNumber'].patchValue(pageNumber, { emitEvent: false });
    this.loadPublicUsers();
  }

  private loadPublicUsers() {
    let filters = this.form.getRawValue();
    console.log("filters", filters);

    this.httpService.GET(PublicUserController.PublicUsers, filters)
      .pipe(takeUntil(this.ngUnsubscribe))
      .subscribe(res => {
        this.publicUsers = res?.data;
        this.total = res?.total;
      });
  }

  delete(item: any) {
    const modalRef = this.modalService.open(DeleteComponent, {
      ...ngbModalOptions,
      windowClass: 'modal modal-danger'
    });
    modalRef.componentInstance.data = item;
    modalRef.componentInstance.url = PublicUserController.Delete(item.id);
    modalRef
      .result
      .then((actionCompleted: boolean) => !actionCompleted || this.activeModal.close(true) || this.loadPublicUsers())
      .catch(() => {
      });
  }

  activate(item: any) {
    const modalRef = this.modalService.open(ActivateComponent, {
      ...ngbModalOptions,
      windowClass: 'modal modal-success'
    });
    modalRef.componentInstance.data = item;
    modalRef.componentInstance.url = PublicUserController.Activate(item.id);
    modalRef
      .result
      .then((actionCompleted: boolean) => !actionCompleted || this.activeModal.close(true) || this.loadPublicUsers())
      .catch(() => {
      });
  }

  deactivate(item: any) {
    const modalRef = this.modalService.open(DeactivateComponent, {
      ...ngbModalOptions,
      windowClass: 'modal modal-danger'
    });
    modalRef.componentInstance.data = item;
    modalRef.componentInstance.url = PublicUserController.Activate(item.id);
    modalRef
      .result
      .then((actionCompleted: boolean) => !actionCompleted || this.activeModal.close(true) || this.loadPublicUsers())
      .catch(() => {
      });
  }
}

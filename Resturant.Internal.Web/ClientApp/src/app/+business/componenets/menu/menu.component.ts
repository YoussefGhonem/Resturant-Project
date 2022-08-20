import { takeUntil, debounceTime } from 'rxjs/operators';
import { Component, Injector, OnInit } from '@angular/core';
import { FormControl, FormGroup, UntypedFormBuilder } from '@angular/forms';
import { BaseComponent } from '@shared/base/base.component';
import { SettingsController } from 'app/+users/controllers';
import { ngbModalOptions } from '@shared/default-values';
import { NgbActiveModal, NgbModal } from '@ng-bootstrap/ng-bootstrap';

@Component({
  selector: 'app-menu',
  templateUrl: './menu.component.html',
  styleUrls: ['./menu.component.scss']
})
export class MenuComponent extends BaseComponent implements OnInit {
  categories: any[];
  subCategories: any[];
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
      { label: 'Menu', active: true }
    ];
    this.initSearchForm()
    this.loadSubCategories()
  }

  private initSearchForm(): void {
    this.form = this._formBuilder.group({
      // Pagination
      pageNumber: new FormControl(1),
      pageSize: new FormControl(10),
      categoryId: new FormControl(null),
    });

    this.form.valueChanges
      .pipe(debounceTime(500))
      .subscribe(res => {
        this.form?.controls['pageNumber'].patchValue(1, { emitEvent: false });
        this.loadSubCategories();
      });
  }

  pageChange(pageNumber: number) {
    this.form.controls['pageNumber'].patchValue(pageNumber, { emitEvent: false });
    this.loadCategories();
  }
  onCategoryChange(id: any) {
    this.form?.controls['categoryId'].patchValue(id);
  }

  loadCategories() {
    let filters = this.form.getRawValue();
    console.log("filters", filters);
    this.httpService.GET(SettingsController.Press, filters)
      .pipe(takeUntil(this.ngUnsubscribe))
      .subscribe(res => {
        this.categories = res;
        console.log("categories", this.categories);
      });
  }

  loadSubCategories() {
    let filters = this.form.getRawValue();
    console.log("filters", filters);
    this.httpService.GET(SettingsController.Press, filters)
      .pipe(takeUntil(this.ngUnsubscribe))
      .subscribe(res => {
        this.subCategories = res.data;
        this.total = this.total;
        console.log("subCategories", this.subCategories);
      });
  }

  create() {
    // const modalRef = this.modalService.open(AddEditPressComponent, {
    //   ...ngbModalOptions,
    //   windowClass: 'modal modal-success',
    //   size: 'lg'
    // });
    // modalRef
    //   .result
    //   .then((actionCompleted: boolean) => !actionCompleted || this.activeModal.close(true) || this.loadData())
    //   .catch(() => {
    //   });
  }
}

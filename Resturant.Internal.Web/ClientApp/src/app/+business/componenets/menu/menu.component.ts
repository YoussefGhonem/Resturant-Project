import { CreateSubcategoryModalComponent } from './create-menu/create-subcategory-modal/create-subcategory-modal.component';
import { takeUntil, debounceTime } from 'rxjs/operators';
import { Component, Injector, OnInit } from '@angular/core';
import { FormControl, FormGroup, UntypedFormBuilder } from '@angular/forms';
import { BaseComponent } from '@shared/base/base.component';
import { NgbActiveModal, NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { BusinessController } from 'app/+business/controllers/BusinessController';
import * as saveAs from 'file-saver';
import * as FileSaver from 'file-saver';
import { CreateSubcategoryComponent } from './create-menu/create-subcategory/create-subcategory.component';
import { ngbModalOptions } from '@shared/default-values';

@Component({
  selector: 'app-menu',
  templateUrl: './menu.component.html',
  styleUrls: ['./menu.component.scss']
})
export class MenuComponent extends BaseComponent implements OnInit {
  categories: any[];
  subCategories: any[];
  categoryDetails: any;
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
    this.loadCategories()
    this.loadSubCategories()
  }

  private initSearchForm(): void {
    this.form = this._formBuilder.group({
      // Pagination
      pageNumber: new FormControl(1),
      pageSize: new FormControl(10),
      categoryId: new FormControl(),
    });

    this.form.valueChanges
      .pipe(debounceTime(500))
      .subscribe(res => {
        this.form?.controls['pageNumber'].patchValue(1, { emitEvent: false });
        this.loadSubCategories();
        if (this.form.controls['categoryId'].value != null)
          this.loadCategoriesDetails();
      });
  }

  pageChange(pageNumber: number) {
    this.form.controls['pageNumber'].patchValue(pageNumber, { emitEvent: false });
    this.loadSubCategories();
  }
  downloadPdf() {
    let url = this.categoryDetails.categoryFileUrl;
    let name = this.categoryDetails.categoryFileName;
    FileSaver.saveAs(url, name);
  }

  UpdeteSubcategory() {
    const modalRef = this.modalService.open(CreateSubcategoryModalComponent, {
      ...ngbModalOptions,
      windowClass: 'modal modal-success',
      size: 'xl'
    });
    modalRef.componentInstance.categoryDetails = this.categoryDetails
    modalRef
      .result
      .then((actionCompleted: boolean) => !actionCompleted || this.activeModal.close(true) || this.loadSubCategories())
      .catch(() => {
      });
  }
  UpdeteCategory() {
    const modalRef = this.modalService.open(CreateSubcategoryModalComponent, {
      ...ngbModalOptions,
      windowClass: 'modal modal-success',
      size: 'xl'
    });
    modalRef.componentInstance.categoryDetails = this.categoryDetails
    modalRef
      .result
      .then((actionCompleted: boolean) => !actionCompleted || this.activeModal.close(true) || this.loadSubCategories())
      .catch(() => {
      });
  }


  onCategoryChange(id: any) {
    this.form?.controls['categoryId'].patchValue(id);
  }

  loadCategories() {
    this.httpService.GET(BusinessController.Categories)
      .pipe(takeUntil(this.ngUnsubscribe))
      .subscribe(res => {
        this.categories = res;
        console.log("categories", this.categories);
      });
  }

  loadSubCategories() {
    let filters = this.form.getRawValue();
    console.log("filters", filters);
    this.httpService.GET(BusinessController.SubCategories, filters)
      .pipe(takeUntil(this.ngUnsubscribe))
      .subscribe(res => {
        this.subCategories = res.data;
        this.total = this.total;
        console.log("subCategories", this.subCategories);
      });
  }

  loadCategoriesDetails() {
    this.httpService.GET(BusinessController.CategoriesDetails(this.form.controls['categoryId'].value))
      .pipe(takeUntil(this.ngUnsubscribe))
      .subscribe(res => {
        this.categoryDetails = res;
        console.log("categoryDetails", this.categoryDetails);
      });
  }

}

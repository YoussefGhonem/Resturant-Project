import { Component, Injector, OnInit } from '@angular/core';
import { FormControl, FormGroup, UntypedFormBuilder } from '@angular/forms';
import { BaseComponent } from '@shared/base/base.component';
import { BusinessController } from 'app/+Business/Controllers/Business';
import { takeUntil, debounceTime } from 'rxjs/operators';
@Component({
  selector: 'app-gallery',
  templateUrl: './gallery.component.html',
  styleUrls: ['./gallery.component.css']
})
export class GalleryComponent extends BaseComponent implements OnInit {
  formGallery!: FormGroup;
  Gallery:any[];
  totalGallery:number=0;
  constructor(private _formBuilderGallery: UntypedFormBuilder,public override injector: Injector) { 
    super(injector);
  }

  ngOnInit(): void {
    this.initSearchForm();
  }
  private initSearchForm(): void {
  
  this.formGallery = this._formBuilderGallery.group({
    // Pagination
    pageNumber: new FormControl(1),
    pageSize: new FormControl(8),
  });
  this.formGallery.valueChanges
  .pipe(debounceTime(500))
  .subscribe(res => {
    this.formGallery?.controls['pageNumber'].patchValue(1, { emitEvent: false });
     this.loadData();
  });
  }

  pageChange(pageNumber: number) {
    this.formGallery.controls['pageNumber'].patchValue(pageNumber, { emitEvent: false });
     this.loadData();
  }

  loadData() {
    let filterGalery=this.formGallery.getRawValue();
    this.httpService.GET(BusinessController.GetGallery,filterGalery).pipe(takeUntil(this.ngUnsubscribe))
    .subscribe(res => {
      this.Gallery = res.data;
      this.totalGallery = this.totalGallery;
      console.log(this.Gallery);
    });

  }

}

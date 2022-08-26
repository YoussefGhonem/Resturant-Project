import { debounceTime, takeUntil } from 'rxjs/operators';
import { Component, Injector, OnInit } from '@angular/core';
import { FormControl, FormGroup, UntypedFormBuilder } from '@angular/forms';
import { BaseComponent } from '@shared/base/base.component';
import { BusinessController } from 'app/+business/controllers/BusinessController';
import * as FileSaver from 'file-saver';

@Component({
  selector: 'app-jobs',
  templateUrl: './jobs.component.html',
  styleUrls: ['./jobs.component.scss']
})
export class JobsComponent extends BaseComponent implements OnInit {
  jobs: any[]
  breadCrumbItems!: Array<{}>;
  total: number = 0;
  form!: FormGroup;

  constructor(
    public override injector: Injector, private _formBuilder: UntypedFormBuilder) {
    super(injector);
  }
  ngOnInit(): void {
    this.breadCrumbItems = [
      { label: 'Home' },
      { label: 'Happenings', active: true }
    ];
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
    this.httpService.GET(BusinessController.Jobs, filters)
      .pipe(takeUntil(this.ngUnsubscribe))
      .subscribe(res => {
        this.jobs = res.data;
        this.total = this.total;
        console.log(this.jobs);
      });
  }
  downloadPdf(url: string, name: string) {
    FileSaver.saveAs(url, name);
  }

}

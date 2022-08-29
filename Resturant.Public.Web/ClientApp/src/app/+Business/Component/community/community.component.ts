import { Component, Injector, OnInit } from '@angular/core';
import { UntypedFormBuilder } from '@angular/forms';
import { BaseComponent } from '@shared/base/base.component';
import { BusinessController } from 'app/+Business/Controllers/Business';
import { takeUntil, debounceTime } from 'rxjs/operators';
@Component({
  selector: 'app-community',
  templateUrl: './community.component.html',
  styleUrls: ['./community.component.css']
})
export class CommunityComponent extends BaseComponent implements OnInit {
 data:any=[];
 constructor(private _formBuilder: UntypedFormBuilder,public override injector: Injector) { 
  super(injector);
}

  ngOnInit(): void {
    this.loadData();
  }

  loadData(){
    this.httpService.GET(BusinessController.GetCommunity).pipe(takeUntil(this.ngUnsubscribe))
    .subscribe(res => {
      this.data = res;
      console.log(this.data);
    });
  }

}

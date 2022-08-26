import { Component, Injector, OnInit } from '@angular/core';
import { BaseComponent } from '@shared/base/base.component';
import { BusinessController } from 'app/+Business/Controllers/Business';
import { takeUntil, debounceTime } from 'rxjs/operators';
@Component({
  selector: 'app-menu',
  templateUrl: './menu.component.html',
  styleUrls: ['./menu.component.css']
})
export class MenuComponent extends BaseComponent implements OnInit {
  Settingdata: any=[];
  constructor(public override injector: Injector) { 
    super(injector);
  }

  ngOnInit(): void {
    this.loadData();
  }

  loadData(){
    this.httpService.GET(BusinessController.Settings).pipe(takeUntil(this.ngUnsubscribe))
    .subscribe(res => {
      this.Settingdata = res;
      console.log(this.Settingdata);
    });
  }
}

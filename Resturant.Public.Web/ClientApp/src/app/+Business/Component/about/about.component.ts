import { Component, Injector, OnInit } from '@angular/core';
import { UntypedFormBuilder } from '@angular/forms';
import { BaseComponent } from '@shared/base/base.component';
import { BusinessController } from 'app/+Business/Controllers/Business';
import { takeUntil, debounceTime } from 'rxjs/operators';
@Component({
  selector: 'app-about',
  templateUrl: './about.component.html',
  styleUrls: ['./about.component.css']
})
export class AboutComponent extends BaseComponent implements OnInit {
  Settingdata: any=[];
  TeamsData:any=[];
  constructor(private _formBuilder: UntypedFormBuilder,private _formBuilderGallery: UntypedFormBuilder,public override injector: Injector) { 
    super(injector);
  }
  ngOnInit(): void {
    this.loadData();
  }
  loadData(){
    this.httpService.GET(BusinessController.Settings).pipe(takeUntil(this.ngUnsubscribe))
    .subscribe(res => {
      this.Settingdata = res;
      console.log( this.Settingdata );
    });
    this.httpService.GET(BusinessController.Teams).pipe(takeUntil(this.ngUnsubscribe)).subscribe(res=>{
      this.TeamsData=res;
    })
  }

}

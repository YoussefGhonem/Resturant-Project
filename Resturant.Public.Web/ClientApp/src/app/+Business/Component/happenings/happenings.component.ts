import { Component, Injector, OnInit } from '@angular/core';
import { UntypedFormBuilder } from '@angular/forms';
import { BaseComponent } from '@shared/base/base.component';
import { BusinessController } from 'app/+Business/Controllers/Business';

@Component({
  selector: 'app-happenings',
  templateUrl: './happenings.component.html',
  styleUrls: ['./happenings.component.css']
})
export class HappeningsComponent extends BaseComponent implements OnInit {

  Data:any={};
  constructor(public override injector: Injector) { 
    super(injector);
  }

  ngOnInit(): void {
    this.loadData();
  }
  loadData(){
    this.httpService.GET(BusinessController.Settings).subscribe({
      next:(res)=>{
        this.Data=res;
        // var size = Object.size(this.Data);
        console.log(this.Data);
          // this.notificationService.success("Sucess","Data")
      },
      error:()=>{
          return;
      }
    })
  }



}

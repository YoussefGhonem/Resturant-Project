import { ToastService } from './../../app/+dashboard/components/dashboard/toast-service';
import { Component, Injector, OnDestroy } from '@angular/core';
import { Subject } from 'rxjs';
import { NgxSpinnerService } from 'ngx-spinner';
import { HttpService } from '@shared/services';
import { NotificationService } from '@shared/services';
import { User } from "app/+auth/models";
import { takeUntil } from "rxjs/operators";
import { AuthService } from "app/+auth/service";

// Lib
export class ServiceLocator {
  static injector: Injector;
}

@Component({
  template: '',
})
export class BaseComponent implements OnDestroy {

  currentUser: User | null = null;
  ngUnsubscribe = new Subject<void>();

  //#region Services
  public spinner: NgxSpinnerService;
  public httpService: HttpService;
  public notificationService: NotificationService;
  public authService: AuthService;
  //#endregion

  constructor(public injector: Injector) {
    this.spinner = this.injector.get(NgxSpinnerService);
    this.httpService = this.injector.get(HttpService);
    this.notificationService = this.injector.get(NotificationService);
    this.authService = this.injector.get(AuthService);

    // Set current user
    this.authService.currentUser$.pipe(takeUntil(this.ngUnsubscribe)).subscribe(user => this.currentUser = user);
  }

  ngOnDestroy(): void {
    this.ngUnsubscribe.next();
    this.ngUnsubscribe.complete();
  }

}

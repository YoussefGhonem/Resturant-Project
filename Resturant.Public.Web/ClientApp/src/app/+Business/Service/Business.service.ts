import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { HttpService } from '@shared/services/http.service';
import { NotificationService } from '@shared/services/notification.service';
@Injectable({
    providedIn: 'root'
  })
  export class BusinessService {
    constructor(
        private _router: Router,
        // private _permissionsService: NgxPermissionsService,
        private _httpService: HttpService,
        private _notificationService: NotificationService,
      ) {}

    // Get Setting Fot Business
    GetSetting(){
        
    }
  }
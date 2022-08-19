import { Component, ElementRef, Inject, OnDestroy, OnInit, Renderer2 } from '@angular/core';
import { Subject } from "rxjs";
import { AuthService } from "app/+auth/service";

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent implements OnInit, OnDestroy {
  title = 'Resturant Management';

  constructor(private _authService: AuthService) { }

  ngOnDestroy(): void {

  }

  ngOnInit(): void {
    // Load ngx permissions
    this._authService.loadPermissions();
  }
}

import { UsersController } from 'app/+users/controllers/UsersController';
import { BaseComponent } from '@shared/base/base.component';
import { Component, Injector, OnInit } from '@angular/core';
import { User } from 'app/+auth/models/user';

// Swiper Slider
// import { SwiperComponent, SwiperDirective } from 'ngx-swiper-wrapper';

// import { TokenStorageService } from 'app/core/services/token-storage.service';

@Component({
  selector: 'profile',
  templateUrl: './profile.component.html',
  styleUrls: ['./profile.component.css']
})

/**
 * Profile Component
 */
export class ProfileComponent extends BaseComponent implements OnInit {

  userInfo: User;
  completionPercentage: number = 0;
  constructor(
      public override injector: Injector
  ) {
    super(injector);
    console.log(this.currentUser);
  }

  ngOnInit(): void {
    this.getCompletionPercentage();
    this.userInfo = this.currentUser;
  }

  getCompletionPercentage() {
    this.httpService.GET(UsersController.getCompletionPercentage, undefined, false)
    .subscribe((cp) => {
      this.completionPercentage = cp
    });
  }

  previousSlideComp() {

  }

  nextSlideComp() {

  }


}

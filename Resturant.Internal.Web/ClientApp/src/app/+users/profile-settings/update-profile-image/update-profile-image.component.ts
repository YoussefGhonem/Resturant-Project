import { UsersController } from 'app/+users/controllers/UsersController';
import { Component, Injector, OnInit, Output, EventEmitter, Input } from '@angular/core';
import { User } from 'app/+auth/models';
import { BaseComponent } from '@shared/base/base.component';

@Component({
  selector: 'update-profile-image',
  templateUrl: './update-profile-image.component.html',
  styleUrls: ['./update-profile-image.component.scss']
})

/**
 * Profile Settings Component
 */
export class UpdateProfileImageComponent extends BaseComponent implements OnInit {

  image: File;
  userInfo: User;
  @Output() onImageChangeSend = new EventEmitter();
  @Input() activeId: number = 1;

  constructor
  (
      public override injector: Injector,
  ) {
    super(injector);
  }

  ngOnInit(): void {
    this.userInfo = this.currentUser;
  }

  onImageChange(event, imageTag) {
    const file = event.target.files[0] as File;
    if (!file) return;

    let reader = new FileReader();
    reader.onloadend = () => {
      imageTag.src = reader.result;
    };

    this.image = file;
    reader.readAsDataURL(this.image);

    console.log(this.image);

    this.onImageChangeSend.emit(this.image);

    // this.httpService.PUT(UsersController.UpdateImage, this.image, undefined)
    //     .subscribe(() => {
    //       this.notificationService.success("Success", "Bingo");
    //     });
  }

}

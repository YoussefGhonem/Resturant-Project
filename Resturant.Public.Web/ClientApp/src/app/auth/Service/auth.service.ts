import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { FormGroup } from '@angular/forms';
import { Router } from '@angular/router';
import { LocalStorageKeys } from '@shared/Default-Values';
import { HttpService } from '@shared/services/http.service';
import { NotificationService } from '@shared/services/notification.service';
import { BehaviorSubject } from 'rxjs';
import { AuthController } from '../Controllers/Auth';
import { User } from '../Models/User';

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  public currentUser$: BehaviorSubject<User | null> = new BehaviorSubject<User | null>(null);

  constructor(
    private _router: Router,
    // private _permissionsService: NgxPermissionsService,
    private _httpService: HttpService,
    private _notificationService: NotificationService,
  ) {
    this.currentUser$?.next(this.currentUser);
  }

  get currentUser(): User {
    return JSON.parse(localStorage.getItem(LocalStorageKeys.User)!);
  }

  get token(): string | null {
    return localStorage.getItem(LocalStorageKeys.AuthToken) || null;
  }

  logout(): void {
    localStorage.removeItem(LocalStorageKeys.User);
    localStorage.removeItem(LocalStorageKeys.AuthToken);

    this.currentUser$.next(null);
    this._router.navigate(['/auth/login']);
  }

  login(body:any) {
    // const body = {
    //   email: email,
    //   password: password
    // };

    return this._httpService.POST(AuthController.Login, body)
      .subscribe((res: string) => {
        // this.updateToken(res);
        this._notificationService.success('Welcome', 'You have logged in successfully! 🎉');
        // this._router.navigate(['/']);
      },(e)=>{
       this._notificationService.error("Error","OOPS,Login Error");
      });
  }
  Register(body:any){
    return this._httpService.POST(AuthController.Register,body).subscribe(()=>{
      this._notificationService.success("Welcome","Register Successd,");
    },(e)=>{
      this._notificationService.error("Error","Register Error");
    })
  }

  // updateToken(token: string): void {
  //   // let user = this.decodeToken(token);
  //   this.currentUser$.next(user);
  //   localStorage.setItem(LocalStorageKeys.AuthToken, token);
  //   localStorage.setItem(LocalStorageKeys.User, JSON.stringify(user));
  //   // this.loadPermissions();
  // }

  // loadPermissions(): void {
  //   let roles = this.currentUser?.roles?.map(x => x?.toString()) || [];
  //   this._permissionsService.loadPermissions(roles);
  // }

  // UpdateUserInfo(user: User): void {
  //   let currentUser = this.currentUser;

  //   currentUser.name = user.name;
  //   currentUser.firstName = user.firstName;
  //   currentUser.lastName = user.lastName;
  //   currentUser.phoneNumber = user.phoneNumber;
  //   currentUser.imageUrl = user.imageUrl;
  //   currentUser.email = user.email;

  //   this.currentUser$.next(currentUser);
  //   localStorage.setItem(LocalStorageKeys.User, JSON.stringify(currentUser));
  // }

  // private decodeToken(token: string): User {
  //   let decoded = jwt_decode(token) as any;
  //   return {
  //     id: decoded?.Id,
  //     firstName: decoded?.FirstName,
  //     lastName: decoded?.LastName,
  //     name: decoded?.Name,
  //     imageUrl: decoded?.ImageUrl,
  //     email: decoded?.Email,
  //     status: decoded?.Status,
  //     phoneNumber: decoded?.PhoneNumber,
  //     roles: typeof decoded?.role == "string" ? [decoded?.role] : decoded?.role
  //   }
  // }

}

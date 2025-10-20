import { HttpClient } from '@angular/common/http';
import {
  inject,
  Injectable,
  Injector,
  OnInit,
  signal,
  WritableSignal,
} from '@angular/core';
import { Login } from '../Interfaces/Request/Login';
import { User } from '../Models/User';
import { AuthResponse } from '../Interfaces/Response/AuthResponse';
import { environment } from '../../environments/environment';
import Swal from 'sweetalert2';
import { TranslateService } from '@ngx-translate/core';

@Injectable({
  providedIn: 'root',
})
export class AuthService {
  user: WritableSignal<User> = signal(null);
  private url = environment.baseUrl + 'Auth';
  private refreshTokenTimeInHours = 1;
  private refreshTokenHandler;
  private translateService: TranslateService;

  constructor(private http: HttpClient, private injector: Injector) {
    Promise.resolve().then(() => {
      this.translateService = this.injector.get(TranslateService);
    });
  }

  Login(model: Login) {
    const url = this.url + `/Login`;
    this.http.post<AuthResponse>(url, model).subscribe({
      next: (response) => this.ManageLogin(response),
      error: (error) => this.manageError(error),
    });
  }

  RefreshToken(refreshToken: string, showHelloMessage) {
    const url = this.url + `/RefreshToken`;
    return this.http
      .post<AuthResponse>(url, { refreshToken: refreshToken })
      .subscribe({
        next: (response) => this.ManageLogin(response, showHelloMessage),
        error: (error) => this.manageError(error),
      });
  }

  Logout() {
    this.user.set(null);

    // clearInterval(this.refreshTokenHandler);

    if (localStorage.getItem('currentUser')) {
      localStorage.removeItem('currentUser');
      localStorage.removeItem('token');
    }
  }

  AutoLogin() {
    if (localStorage.getItem('currentUser')) {
      let localStorageUser = JSON.parse(localStorage.getItem('currentUser'));

      let singInUser = new User(
        localStorageUser.Username,
        localStorageUser._token,
        localStorageUser._expireOn,
        localStorageUser._refreshToken,
        localStorageUser._refreshTokenExpireOn
      );

      if (
        singInUser?.getToken &&
        singInUser.expireOnHours > this.refreshTokenTimeInHours
      ) {
        this.user.set(singInUser);
      }
      // else if (singInUser?.getRefreshToken) {
      //   this.RefreshToken(singInUser?.getRefreshToken, true);
      // }
    } else {
      this.Logout();
    }
  }

  AutoRefreshToken() {
    var refreshToken = this.user()?.getRefreshToken;
    if (refreshToken) {
      const timeInMillSecounds = this.refreshTokenTimeInHours * 60 * 60 * 1000;

      clearInterval(this.refreshTokenHandler);

      this.refreshTokenHandler = setInterval(() => {
        this.RefreshToken(refreshToken, false);
      }, timeInMillSecounds);
    }
  }

  isPublicEndpoint(route: string): boolean {
    const publicEndpoints = [
      '/Login',
      '/RefreshToken',
      '/Refresh',
      '/public',
      '/ar.json',
      '/en.json',
      '/fr.json',
    ];
    return publicEndpoints.some((endpoint) => route.includes(endpoint));
  }

  private ManageLogin(response: AuthResponse, ShowHelloMessage = true) {
    const user: User = new User(
      response.userName,
      response.token,
      response.expireOn,
      response.refreshToken,
      response.refreshTokenExpireOn
    );

    this.user.set(user);
    localStorage.setItem('currentUser', JSON.stringify(user));
    if (ShowHelloMessage) {
      Swal.fire({
        icon: 'success',
        title: this.translateService.instant('Hi') + ` ${user.Username}`,
        showConfirmButton: false,
        timer: environment.sweetAlertTimeOut,
      });
    }
  }

  private manageError(resError) {
    const errorObject = resError.error;
    let errorList: string[] = [];
    if (resError.status == 500) {
      errorList.push('Internal Server Error');
    } else if (errorObject.errors) {
      Object.keys(errorObject.errors).forEach((key) => {
        errorList.push(...errorObject.errors[key]);
      });
    } else if (errorObject) {
      errorList.push(errorObject['message']);
    } else {
      errorList.push('Unknown Error Occured');
    }

    errorList.forEach((el) => {
      Swal.fire({
        icon: 'error',
        title: this.translateService.instant('Error'),
        text: el,
        showConfirmButton: true,
        confirmButtonText: this.translateService.instant('Ok'),
      });
    });
  }
}

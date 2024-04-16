import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { TokenStorageService } from '../TokenService/token-storage.service';
import { environment } from '../../../../environments/environment.prod';
import { BehaviorSubject, Observable, Subject, map } from 'rxjs';
import { User } from '../../../models/user';
import { CookieService } from 'ngx-cookie-service';

@Injectable({
  providedIn: 'root'
})
export class AuthService {
  uri = 'https://localhost:7079/api';
  private userSubject: BehaviorSubject<User | null>;
  public user: Observable<User | null>;

  public $refreshToken = new Subject<boolean>;

  constructor(private http: HttpClient, private router: Router, private tokenService: TokenStorageService, private cookieService : CookieService) { 
    this.userSubject = new BehaviorSubject<User | null>(null);
    this.user = this.userSubject.asObservable();

    this.$refreshToken.subscribe((res:any) => {
      this.refreshToken();
    })
  }

  public get userValue() {
    return this.userSubject.value;
  }

  login(login:string, password: string) {
    return this.http.post(`${environment.apiUrl}/auth/login`, {Login:login, Password:password})
            .pipe(map(user => {
                this.tokenService.clearTokens();
                this.userSubject.next(user);

                if((user as User).refreshToken != null || (user as User).accessToken != null) {
                  this.cookieService.set("refreshToken", `${(user as User).refreshToken}`,undefined, "/"),
                  this.cookieService.set("accessToken", `${(user as User).accessToken}`, undefined, "/")
                }
                return user;
            }));
  }

  logout() {
    this.http.post(`${environment.apiUrl}/auth/logout`, {}).subscribe();
    this.tokenService.signOut();
    this.userSubject.next(null);
    this.router.navigate(['/login']);
  }

  refreshToken() {
    const req = {
      RefreshToken: this.tokenService.getRefreshToken(),
      AccessToken: this.tokenService.getToken(),
    };

    console.log(req);
    this.http.post(`${environment.apiUrl}/auth/refresh`,req).subscribe((res: any) => {
      console.log(res);
      this.tokenService.clearTokens();
      this.tokenService.saveToken(res.accessToken);
      this.tokenService.saveRefreshToken(res.refreshToken);
    });
  }
}

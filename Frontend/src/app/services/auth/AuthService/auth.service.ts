import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { TokenStorageService } from '../TokenService/token-storage.service';

@Injectable({
  providedIn: 'root'
})
export class AuthService {
  uri = 'https://localhost:7079/api';

  constructor(private http: HttpClient, private router: Router, private tokenService: TokenStorageService) { }

  login(login:string, password: string) {
    this.http.post(this.uri + '/auth/login', {login:login, password:password})
      .subscribe((response: any) => {
        console.log(response);
        
        this.tokenService.saveToken(response.AccessToken);
        this.tokenService.saveRefreshToken(response.RefreshToken);
      })
  }
}

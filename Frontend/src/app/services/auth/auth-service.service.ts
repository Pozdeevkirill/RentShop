import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';

const AUTH_API = 'http://localhost:8080/api/auth/';

const httpOption = {
  headers: new HttpHeaders({'Content-Type': 'application/json'})
}


@Injectable({
  providedIn: 'root'
})
export class AuthServiceService {

  constructor(private http: HttpClient) { }

  refreshToken(token:string) {
    return this.http.post(AUTH_API + 'refreshtoken', {
      refreshToken: token
    }, httpOption);
  }

}

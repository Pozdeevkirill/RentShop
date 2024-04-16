import { Injectable } from '@angular/core';
import { CookieService } from 'ngx-cookie-service';

const TOKEN_KEY = 'accessToken';
const REFRESHTOKEN_KEY = 'refreshToken';

@Injectable({
  providedIn: 'root'
})
export class TokenStorageService {

  constructor(private cookieService : CookieService) { }

  signOut(): void {
    this.clearTokens();
  }

  public saveToken(token: string): void {      
    this.cookieService.deleteAll(TOKEN_KEY);
    this.cookieService.set(TOKEN_KEY, token, undefined,"/");
  }

  public getToken(): string | null {
    return this.cookieService.get(TOKEN_KEY)
  }

  public saveRefreshToken(token: string): void {
    this.cookieService.deleteAll(REFRESHTOKEN_KEY);
    this.cookieService.set(REFRESHTOKEN_KEY, token, undefined,"/");
  }

  public getRefreshToken(): string | null {
    return this.cookieService.get(REFRESHTOKEN_KEY);
  }

  public isLoggedIn() {
    return this.cookieService.get(REFRESHTOKEN_KEY) != null && this.cookieService.get(TOKEN_KEY) != null;
  }

  public clearTokens() {
    this.cookieService.deleteAll(TOKEN_KEY);
    this.cookieService.deleteAll(REFRESHTOKEN_KEY);
  }

  getCookieValue(cookieName: string): string {
    const name = cookieName + "=";
    const decodedCookie = decodeURIComponent(document.cookie);
    const cookieArray = decodedCookie.split(';');
  
    for (let i = 0; i < cookieArray.length; i++) {
      let cookie = cookieArray[i].trim();
      if (cookie.indexOf(name) === 0) {
        return cookie.substring(name.length, cookie.length);
      }
    }
    
    return "";
  }
}

import { HttpErrorResponse, HttpInterceptorFn, HttpRequest } from '@angular/common/http';
import { inject } from '@angular/core';
import { CookieService } from 'ngx-cookie-service';
import { TokenStorageService } from '../../services/auth/TokenService/token-storage.service';
import { catchError, throwError } from 'rxjs';
import { AuthService } from '../../services/auth/AuthService/auth.service';

export const customHttpInterceptor: HttpInterceptorFn = (req, next) => {

  const tokenService = inject(TokenStorageService);
  const authService = inject(AuthService);

  const token = tokenService.getToken();

  const cloneReq = req.clone({
    setHeaders:{
      Authorization: `${token}`
    }
  });

  return next(cloneReq).pipe(
    catchError((error: HttpErrorResponse) => {
      if(error.status === 401) {
          authService.$refreshToken.next(true);
          next(cloneReq);
      }

      return throwError(error);
    })
  );

  private handle401Error(req: HttpRequest, next: HttpHandler) {

  }
};

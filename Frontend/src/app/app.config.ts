import { ApplicationConfig } from '@angular/core';
import { provideRouter } from '@angular/router';

import { routes } from './app.routes';
import { provideClientHydration } from '@angular/platform-browser';
import { HTTP_INTERCEPTORS, provideHttpClient, withFetch, withInterceptors } from '@angular/common/http';
import { customHttpInterceptor } from './helpers/CustomHttp/custom-http.interceptor';

export const appConfig: ApplicationConfig = {
  providers: [
              //{provide: HTTP_INTERCEPTORS, useClass: JwtInterceptor, multi: true},
              provideRouter(routes), 
              provideClientHydration(), 
              provideHttpClient(withFetch(), withInterceptors([customHttpInterceptor])),
              //{ provide: HTTP_INTERCEPTORS, useClass: HttpRequestInterceptor, multi: true }
            //{ provide: HTTP_INTERCEPTORS, useClass: ErrorInterceptor, multi: true }
          ]
};

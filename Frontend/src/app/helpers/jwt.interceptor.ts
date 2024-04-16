import { HttpEvent, HttpHandler, HttpInterceptor, HttpRequest } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { AuthService } from "../services/auth/AuthService/auth.service";
import { Observable } from "rxjs";
import { TokenStorageService } from "../services/auth/TokenService/token-storage.service";

@Injectable()
export class JwtInterceptor implements HttpInterceptor {
    constructor(private authenticationService: AuthService, private tokenService: TokenStorageService) { }


    
    intercept(request: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
        // Clone the request to add the new header
        //const clonedRequest = request.clone({ headers: request.headers.append('Authorization', 'Bearer 123') });
        const clonedRequest = request.clone({ 
            headers: request.headers.set('Authorization', 'Bearer 123')
         });

        // Pass the cloned request instead of the original request to the next handle
        return next.handle(clonedRequest);
    }
}
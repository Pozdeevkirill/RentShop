import { catchError, of } from 'rxjs';
import { AuthService } from '../services/auth/AuthService/auth.service';

export function appInitializer(authenticationService: AuthService) {
    return () => authenticationService.refreshToken()
    .pipe(
        // catch error to start app on success or failure
        catchError(() => of())
    );
}
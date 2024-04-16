
import { Component } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { AuthService } from '../../../services/auth/AuthService/auth.service';
import { HttpClient } from '@angular/common/http';
import { first } from 'rxjs';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'app-login',
  standalone: true,
  imports: [FormsModule],
  templateUrl: './login.component.html',
  styleUrl: './login.component.css'
})
export class LoginComponent {
  loginValue: string = "";
  passwordValue: string = "";

  constructor(
    private authService: AuthService, 
    private http: HttpClient,
    private route: ActivatedRoute,
    private router: Router) {}

  login() {
    this.authService.login(this.loginValue,this.passwordValue)
     .pipe(first())
     .subscribe({
      next: () => {
        const returnUrl = this.route.snapshot.queryParams['returnUrl'] || '/';
        this.router.navigate([returnUrl]);
      },
      error: error => {
        console.log(error);
      }
     });
  }
}

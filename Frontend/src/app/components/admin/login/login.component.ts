
import { Component } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { AuthService } from '../../../services/auth/AuthService/auth.service';
import { HttpClient } from '@angular/common/http';

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

  constructor(private authService: AuthService, private http: HttpClient) {}

  login() {
    console.log(this.loginValue, this.passwordValue);
    this.authService.login(this.loginValue,this.passwordValue);
  }
}

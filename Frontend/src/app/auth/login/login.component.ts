import { Component } from '@angular/core';
import { FormsModule, NgForm } from "@angular/forms";
import { HttpClient, HttpHeaders, HttpErrorResponse } from '@angular/common/http';
import { Router } from '@angular/router';
import { AuthenticatedResponse } from '../core/interfaces/AuthenticatedResponse';

@Component({
  selector: 'app-login',
  standalone: true,
  imports: [FormsModule],
  templateUrl: './login.component.html',
  styleUrl: './login.component.css'
})
export class LoginComponent {

  constructor(private router:Router, private http: HttpClient){}

  loginValue: string = "";
  passwordValue: string = "";

  login() {
    this.http.post<AuthenticatedResponse>("https://localhost:7079/api/auth/login", {login: this.loginValue, password: this.passwordValue}, {
      headers: new HttpHeaders({ "Content-Type": "application/json"})
    })
    .subscribe({
      next: (response: AuthenticatedResponse) => {
        const token = response.token;
        const refreshToken = response.refreshToken;
        localStorage.setItem("jwt", token); 
        localStorage.setItem("refreshToken", refreshToken);
        this.router.navigate(["/"]);
      },
      error: (err: HttpErrorResponse) => console.log("error")
    })
  }
}

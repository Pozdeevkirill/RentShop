import { HttpClient } from '@angular/common/http';
import { Component } from '@angular/core';
import { environment } from '../../../../environments/environment.prod';

@Component({
  selector: 'app-header',
  standalone: true,
  imports: [],
  templateUrl: './header.component.html',
  styleUrl: './header.component.css'
})
export class HeaderComponent {
  /**
   *
   */
  constructor(private http:HttpClient) {}
  test() {
    this.http.get(`${environment.apiUrl}/auth/test`).subscribe(res => {
      console.log(res);
    })
  }
}

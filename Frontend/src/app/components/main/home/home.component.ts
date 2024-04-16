import { Component } from '@angular/core';
import { environment } from '../../../../environments/environment';
import { BehaviorSubject, Observable, map } from 'rxjs';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-home',
  standalone: true,
  imports: [],
  templateUrl: './home.component.html',
  styleUrl: './home.component.css'
})
export class HomeComponent {
  private reqStr: BehaviorSubject<string | null>;
  public req: Observable<string | null>;
  constructor(private http : HttpClient) {
    this.reqStr = new BehaviorSubject<string | null>(null);
    this.req = this.reqStr.asObservable();
  }

  test() {
    console.log("test");
    this.http.get(`${environment.apiUrl}/auth/test`)
    .pipe(map((req) => {
      console.log(req);
    }))
    .subscribe({
      next: () => {
        console.log(123);
      },
      error: error => {
        console.log(error);
      }
     });
  }
}

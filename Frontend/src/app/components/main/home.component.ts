import { Component } from '@angular/core';
import { BehaviorSubject, Observable } from 'rxjs';
import { RouterOutlet } from '@angular/router';
import { HeaderComponent } from './header/header.component';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-main',
  standalone: true,
  imports: [RouterOutlet, HeaderComponent],
  templateUrl: './main.component.html',
  styleUrl: './main.component.css'
})
export class MainComponent {
  private reqStr: BehaviorSubject<string | null>;
  public req: Observable<string | null>;
  constructor(private http : HttpClient) {
    this.reqStr = new BehaviorSubject<string | null>(null);
    this.req = this.reqStr.asObservable();
  }
}

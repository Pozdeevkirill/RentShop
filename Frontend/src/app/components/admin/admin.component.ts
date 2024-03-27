import { Component, NgModule } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { SpinnerComponent } from '../common/spinner/spinner.component';

@Component({
  selector: 'app-admin',
  standalone: true,
  imports: [RouterOutlet, SpinnerComponent],
  templateUrl: './admin.component.html',
  styleUrl: './admin.component.css'
})
export class AdminComponent {

}

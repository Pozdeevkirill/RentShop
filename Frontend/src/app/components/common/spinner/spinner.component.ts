import { Component, ElementRef } from '@angular/core';

@Component({
  selector: 'spinner',
  standalone: true,
  imports: [],
  templateUrl: './spinner.component.html',
  styleUrl: './spinner.component.css'
})
export class SpinnerComponent {
  constructor(private el: ElementRef) {}
  s: Spinner = new Spinner(this.el);
  r:void = this.s.spinner();
}

class Spinner {
  constructor(private el: ElementRef) {}

  spinner():void {
    setTimeout(() => {
      this.el.nativeElement.querySelector("#spinner").classList.remove("show");
    },1);
  }

  start():void {
    this.el.nativeElement.querySelector("#spinner").classList.add("show");
  }

  stop():void {
    this.el.nativeElement.querySelector("#spinner").classList.remove("show");
  }
}

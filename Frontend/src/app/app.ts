import { Component } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { NavbarComponent } from './shared/navbar/navbar.component';
import { Footer } from "./shared/footer/footer";

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [RouterOutlet, NavbarComponent, Footer],
  template: `
    <app-navbar />
    <router-outlet />
    <app-footer/>
  `,
  styles: []
})
export class App {}

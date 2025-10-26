import { Component } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { RouterLink } from '@angular/router';
import { NavbarComponent } from "./components/navbar/navbar.component";
import { FooterHomepageComponent } from './components/footer-homepage/footer-homepage.component';

@Component({
  selector: 'app-root',
  imports: [RouterOutlet, NavbarComponent, FooterHomepageComponent],
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})
export class AppComponent {
  title = 'EcommerceStore';
}

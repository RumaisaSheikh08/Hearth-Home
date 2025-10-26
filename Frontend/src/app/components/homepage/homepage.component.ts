import { Component } from '@angular/core';
import { FooterHomepageComponent } from "../footer-homepage/footer-homepage.component";
import { RouterLink } from '@angular/router';
@Component({
  selector: 'app-homepage',
  imports: [RouterLink],
  templateUrl: './homepage.component.html',
  styleUrl: './homepage.component.css'
})
export class HomepageComponent {
}

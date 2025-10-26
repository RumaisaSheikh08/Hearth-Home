import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { GetcatalogueService } from '../../services/getcatalogue.service';
import { Router } from '@angular/router';
import { RouterLink } from '@angular/router';
@Component({
  selector: 'app-catalogue',
  imports: [RouterLink],
  templateUrl: './catalogue.component.html',
  styleUrl: './catalogue.component.css'
})
export class CatalogueComponent implements OnInit {
  data: any;
  constructor(private httpClient : HttpClient, private getCatalogue: GetcatalogueService , private router: Router){}
  ngOnInit(): void {
    this.getCatalogue.getData().subscribe(
      response => {
        this.data = response;
        console.log('Received Data: ', this.data);
      }
    );
  }
}
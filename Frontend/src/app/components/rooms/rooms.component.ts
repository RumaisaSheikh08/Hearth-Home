import { Component } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { OnInit } from '@angular/core';
import { GetcataloguecategoryService } from '../../services/getcataloguecategory.service';
import { NgFor } from '@angular/common';
import { CommonModule } from '@angular/common';
import { RoomdatatransferService } from '../../services/roomdatatransfer.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-rooms',
  standalone : true,
  imports: [CommonModule],
  templateUrl: './rooms.component.html',
  styleUrl: './rooms.component.css'
})
export class RoomsComponent {
  data : any;
  constructor(private route: ActivatedRoute ,  private getCatalogueCategory: GetcataloguecategoryService,
    private dataTransferService : RoomdatatransferService, private router: Router
  ){}
  ngOnInit(){
    localStorage.removeItem("RoomDetailsData");
    console.log("Data removed from local storage" , localStorage.getItem("RoomDetailsData"));
    this.route.paramMap.subscribe(params => {
      const categoryName = params.get('categoryName');
      console.log('Received Category Name: ', categoryName);
      if(categoryName)
      {
        this.getCatalogueCategory.getDataByCategory(categoryName).subscribe(
          response => {
            this.data = response;
            console.log('Categorized Data Received: ', this.data);
          },
          error =>{
            console.log('Error fetching data from api')
          }
        )
      }    
    })

  }

  sendRoomData(data : any): void{
    console.log('Selected Room Data' , data);
    localStorage.setItem("RoomDetailsData" , JSON.stringify(data));
    this.dataTransferService.changeData(data);
    this.router.navigate(['/roomdetails']);
  }
}

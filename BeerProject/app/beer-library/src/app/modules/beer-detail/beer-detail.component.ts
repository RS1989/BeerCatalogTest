import { Component, OnInit, Input } from '@angular/core';
import { beerHttpService } from '../../service/beerHttpService';
import { Beer } from '../../Models/beer';


@Component({
  selector: 'app-beer-detail',
  templateUrl: './beer-detail.component.html',
  styleUrls: ['./beer-detail.component.css']
})
export class BeerDetailComponent implements OnInit {

  constructor(private beerService: beerHttpService) { 
    
  }
  @Input() id:string;
  beer: Beer = null;

  getBeer(){
    this.beerService.getBeer(this.id).subscribe(data=>{
      this.beer = data;
    });  
  }

  ngOnInit() {
   this.getBeer();
  }

}

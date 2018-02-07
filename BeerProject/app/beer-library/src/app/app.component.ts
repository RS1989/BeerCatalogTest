import { Component, OnInit } from '@angular/core';
//import { Http, Response, Headers } from '@angular/http';
//import 'rxjs/add/operator/map';
import { Beers } from './Models/beers';
import { Beer } from './Models/beer';
import { Glasses } from './Models/Glasses';
import { RequestParam } from './Models/request';
import { CheckboxClass } from './Models/checkboxModel';
import { beerHttpService } from './service/beerHttpService';
import { BeerDetailComponent } from './modules/beer-detail/beer-detail.component';



@Component({
  selector: '[app-root]',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  beers: Beers = null;
  glasses: Glasses = null;
  param: RequestParam = {
    page: '1',
    query: '',
    withBreweries: 'N',
    withIngredients: 'N',
    withLocations: 'N',
    withSocialAccounts: 'N',
    order: '',
    sort: ''
  };
  checkbox: CheckboxClass = {
    withBreweriesCheckingModel: false,
    withIngredientsCheckingModel: false,
    withLocationsCheckingModel: false,
    withSocialAccountsCheckingModel: false
  }

  public constructor(private beerService: beerHttpService) {
    this.getBeers();
  }

  showDetail(beer: Beer) {
    if(!beer.showDetail){
      beer.showDetail = true;
    } else{
      beer.showDetail = false;
    }
  }

  private getBeers() {
    this.beerService.getBeers(this.param).subscribe(data => {
      this.beers = data;
    });
  }

  private searchBeers() {
    this.beerService.searchBeers(this.param).subscribe(data => {
      this.beers = data;
    });
  }

  pageChanged(page: any) {
    this.param.page = page;
    if (this.param.query) {
      this.searchBeers();
    } else {
      this.getBeers();
    }
  }

  searchClick(value: string) {
    this.searchBeers();
  }

  onCheckBoxChange(event: any, value: any) {
    if (value === 'withBreweries') {
      if (event) {
        this.param.withBreweries = 'Y';
      } else {
        this.param.withBreweries = 'N';
      }
    }
    if (value === 'withSocialAccounts') {
      if (event) {
        this.param.withSocialAccounts = 'Y';
      } else {
        this.param.withSocialAccounts = 'N';
      }
    }
    if (value === 'withIngredients') {
      if (event) {
        this.param.withIngredients = 'Y';
      } else {
        this.param.withIngredients = 'N';
      }
    }
    if (value === 'withLocations') {
      if (event) {
        this.param.withLocations = 'Y';
      } else {
        this.param.withLocations = 'N';
      }
    }
    if (this.param.query) {
      this.searchBeers();
    } else {
      this.getBeers();
    }
  }

}

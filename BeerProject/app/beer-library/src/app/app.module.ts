import { BrowserModule } from '@angular/platform-browser';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { NgModule } from '@angular/core';
import { AppComponent } from './app.component';
import { HttpModule } from '@angular/http';
import { HttpClientModule } from '@angular/common/http'; 
import { NgxPaginationModule } from 'ngx-pagination';
import { beerHttpService } from './service/beerHttpService';
import { BeerDetailComponent } from './modules/beer-detail/beer-detail.component';



@NgModule({
  imports: [
    BrowserModule,
    HttpModule,
    FormsModule,
    ReactiveFormsModule,
    NgxPaginationModule,

  ],
  declarations: [AppComponent, BeerDetailComponent],
  providers: [
    beerHttpService,
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }

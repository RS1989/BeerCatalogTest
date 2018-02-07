import { Injectable } from '@angular/core';
import { Http, Response } from '@angular/http';
import { Observable } from 'rxjs/Observable';
import { Constant } from '../constant/constant';
import { Beers } from '../models/beers';
import { RequestParam } from '../models/request'
import 'rxjs/add/operator/map';
import 'rxjs/add/operator/do';
import { of } from 'rxjs/observable/of';
import { Beer } from '../Models/beer';

@Injectable()
export class beerHttpService {
    constructor(private http: Http) {

    }

    getBeers(request: RequestParam): Observable<Beers> {
        return this.http.post(Constant.GetBeersEndPoint, request)
            .map((res:Response) => res.json());
    };

    searchBeers(request: RequestParam): Observable<Beers> {
        return this.http.post(Constant.GetBearsSearchEndPoint, request)
            .map((res:Response) => res.json());
    };
    
    getBeer(request: string): Observable<Beer>{
        return this.http.get(Constant.GetBearEndPoint + request)
        .map((res:Response)=> res.json());
    };
}
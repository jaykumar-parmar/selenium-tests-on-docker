import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { PeriodicElement } from './table-pagination-example';

@Injectable({
    providedIn: 'root'
})
export class DataService {

    constructor(private http: HttpClient) { }

    getData() {
        return this.http.get<PeriodicElement[]>("http://api:3000/elements");
    }
}
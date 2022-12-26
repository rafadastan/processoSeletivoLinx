import { Injectable } from '@angular/core';
import { Customer } from '../Models/customer';
import {HttpClient} from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { delay, first, Observable, tap } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class CustomersService {

  resource: string = environment.apiUrl + "/customer";

  constructor(private httpClient: HttpClient) { }

  listCustomers(): Observable<Customer[]>{
    return this.httpClient.get<Customer[]>(this.resource)
    .pipe(
      first(),
      delay(1000),
      tap(customer => console.log(customer))
    );
  }

  createCustomers(data: Customer){
    return this.httpClient.post<Customer>(this.resource, data);
  }
}

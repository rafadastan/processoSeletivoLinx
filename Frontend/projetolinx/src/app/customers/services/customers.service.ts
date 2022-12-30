import { Injectable } from '@angular/core';
import { Customer } from '../Models/customer';
import { HttpClient } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { delay, first, Observable, tap } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class CustomersService {

  resource: string = environment.apiUrl + "/customer";

  constructor(private httpClient: HttpClient) { }

  listCustomers(): Observable<Customer[]> {
    return this.httpClient.get<Customer[]>(this.resource)
      .pipe(
        first(),
        delay(1000),
        tap(customer => console.log(customer))
      );
  }

  createCustomers(data: Partial<Customer>) {
    console.log(data);
    if (data.customerId) {
      console.log(data.customerId);
      return this.update(data);
    }
    console.log('create' + data);
    return this.create(data);
  }

  updateCustomers(data: Partial<Customer>) {
    return this.update(data);
  }

  getCustomer(id: string) {
    console.log(id);
    return this.httpClient.get<Customer>(`${this.resource}/${id}`);
  }

  private create(data: Partial<Customer>) {
    return this.httpClient.post<Customer>(this.resource, data).pipe(first());
  }

  private update(data: Partial<Customer>) {
    return this.httpClient.put<Customer>(`${this.resource}/${data.customerId}`, data)
      .pipe(first());
  }

  remove(id: string) {
    return this.httpClient.delete(`${this.resource}/${id}`)
      .pipe(first());
  }
}

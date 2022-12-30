import { Injectable } from '@angular/core';
import {
  Resolve,
  RouterStateSnapshot,
  ActivatedRouteSnapshot
} from '@angular/router';
import { Observable, of } from 'rxjs';
import { Customer } from '../Models/customer';
import { CustomersService } from '../services/customers.service';

@Injectable({
  providedIn: 'root'
})

export class CustomerResolver implements Resolve<Customer> {

  constructor(private customerService: CustomersService) { }

  resolve(route: ActivatedRouteSnapshot, state: RouterStateSnapshot): Observable<Customer> {
    if (route.params && route.params['id']) {
      return this.customerService.getCustomer(route.params['id']);
    }
    return of(
      {
        customerId: '',
        name: '',
        cpf: '',
        addressDto: { 
          addressId: '',
          customerId: '',
          street: '',
          city: '',
          state: '',
          neighborhood: '',
          number: '',
          cep: ''
        }
      }
    );
  }
}

import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';


import { CustomersRoutingModule } from './customers-routing.module';
import { CustomersComponent } from './Containers/customers/customers.component';
import { AppMaterialModule } from '../shared/app-material/app-material.module';
import { HttpClientModule } from '@angular/common/http';
import { SharedModule } from '../shared/shared.module';
import { CustomerFormComponent } from './Containers/customer-form/customer-form.component';
import { ReactiveFormsModule } from '@angular/forms';
import { CustomersListComponent } from './Components/customers-list/customers-list.component';


@NgModule({
  declarations: [
    CustomersComponent,
    CustomerFormComponent,
    CustomersListComponent
  ],
  imports: [
    CommonModule,
    CustomersRoutingModule,
    AppMaterialModule,
    HttpClientModule,
    SharedModule,
    ReactiveFormsModule
  ]
})
export class CustomersModule { }

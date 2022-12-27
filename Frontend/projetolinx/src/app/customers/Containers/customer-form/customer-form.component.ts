import { Component, OnInit } from '@angular/core';
import { NonNullableFormBuilder } from '@angular/forms';
import { MatSnackBar } from '@angular/material/snack-bar';
import { CustomersService } from '../../services/customers.service';
import { Location } from '@angular/common';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-customer-form',
  templateUrl: './customer-form.component.html',
  styleUrls: ['./customer-form.component.scss']
})
export class CustomerFormComponent implements OnInit {

  form = this.formBuilder.group({
    name: [''],
    cpf: ['']
  });

  constructor(private formBuilder: NonNullableFormBuilder,
    private customerService: CustomersService,
    private snackBar: MatSnackBar,
    private location: Location,
    private route: ActivatedRoute) {  }

  ngOnInit(): void {

  }

  onSubmit() {
    this.customerService.createCustomers(this.form.value)
      .subscribe(
        success => this.onSuccess(),
        result => this.form.reset(),
        () => this.onError())
  }

  onCancel() {
    this.location.back();
  }

  private onSuccess(){
    this.snackBar.open('cliente salvo com sucesso.', '', {duration: 5000})
    this.onCancel();
  }

  private onError(){
    this.snackBar.open('Erro ao salvar cliente.', '', {duration: 5000})

  }
}

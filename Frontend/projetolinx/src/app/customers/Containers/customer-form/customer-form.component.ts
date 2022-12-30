import { Component, OnInit } from '@angular/core';
import { NonNullableFormBuilder, Validators } from '@angular/forms';
import { MatSnackBar } from '@angular/material/snack-bar';
import { CustomersService } from '../../services/customers.service';
import { Location } from '@angular/common';
import { ActivatedRoute } from '@angular/router';
import { Customer } from '../../Models/customer';
import { Observable } from 'rxjs';

@Component({
  selector: 'app-customer-form',
  templateUrl: './customer-form.component.html',
  styleUrls: ['./customer-form.component.scss']
})
export class CustomerFormComponent implements OnInit {

  form = this.formBuilder.group({
    customerId: [''],
    name: ['', [
      Validators.required,
      Validators.minLength(3),
      Validators.maxLength(200)]
    ],
    cpf: ['', [
      Validators.required,
      Validators.minLength(1),
      Validators.maxLength(11)]
    ],
    street: ['', [
      Validators.required,
      Validators.minLength(1),
      Validators.maxLength(100)]
    ],
    city: ['', [
      Validators.required,
      Validators.minLength(1),
      Validators.maxLength(100)]
    ],
    state: ['', [
      Validators.required,
      Validators.minLength(1),
      Validators.maxLength(100)]
    ],
    neighborhood: ['', [
      Validators.required,
      Validators.minLength(1),
      Validators.maxLength(100)]
    ],
    number: ['', [
      Validators.required,
      Validators.minLength(1),
      Validators.maxLength(100)]
    ],
    cep: ['', [
      Validators.required,
      Validators.minLength(1),
      Validators.maxLength(8)]
    ]
  });

  constructor(private formBuilder: NonNullableFormBuilder,
    private customerService: CustomersService,
    private snackBar: MatSnackBar,
    private location: Location,
    private route: ActivatedRoute) { }

  ngOnInit(): void {
    const customer: Customer = this.route.snapshot.data['customer'];
    const getCustomer = this.customerService.getCustomer(customer.customerId);

    getCustomer.subscribe(
      (data: Customer) => {
        console.log(data);
        this.form.controls.customerId.setValue(data.customerId);
        this.form.controls.name.setValue(data.name);
        this.form.controls.cpf.setValue(data.cpf);
        this.form.controls.street.setValue(data.addressDto.street);
        this.form.controls.city.setValue(data.addressDto.city);
        this.form.controls.state.setValue(data.addressDto.state);
        this.form.controls.neighborhood.setValue(data.addressDto.neighborhood);
        this.form.controls.number.setValue(data.addressDto.number);
        this.form.controls.cep.setValue(data.addressDto.cep);
      }
    )
  }

  onSubmit() {  
    this.customerService.createCustomers(this.form.value)
      .subscribe(
        success => this.onSuccess(),
        error => this.onError())
  }

  onCancel() {
    this.location.back();
  }

  getErrorMessage(fieldName: string) {
    const field = this.form.get(fieldName);

    if (field?.hasError('required')) {
      return 'campo obrigatório';
    }

    if (field?.hasError('minlength')) {
      const requiredLength = field.errors ? field.errors['minlength']['requiredLength'] : 3;
      return `tamanho mínimo ${requiredLength}`;
    }

    if (field?.hasError('maxlength')) {
      const requiredLength = field.errors ? field.errors['maxlength']['requiredLength'] : 200;
      return `tamanho mínimo ${requiredLength}`;
    }

    return 'campo invalido';
  }
  private onSuccess() {
    this.snackBar.open('cliente salvo com sucesso.', '', { duration: 5000 })
    this.onCancel();
  }

  private onError() {
    this.snackBar.open('Erro ao salvar cliente.', '', { duration: 5000 })
  }
}

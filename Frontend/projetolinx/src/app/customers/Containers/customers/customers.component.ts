import { Component, OnInit } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { ActivatedRoute, Router } from '@angular/router';
import { catchError, Observable, of } from 'rxjs';
import { ErrorDialogComponent } from 'src/app/shared/components/error-dialog/error-dialog.component';
import { Customer } from '../../Models/customer';
import { CustomersService } from '../../services/customers.service';

@Component({
  selector: 'app-customers',
  templateUrl: './customers.component.html',
  styleUrls: ['./customers.component.scss']
})
export class CustomersComponent implements OnInit {

  customers$: Observable<Customer[]>;
  customerAny: any[] = [];

  constructor(
      private customerService: CustomersService,
      public dialog: MatDialog,
      private router: Router,
      private route: ActivatedRoute
    ) {
    this.customers$ = this.customerService.listCustomers()
    .pipe(
      catchError(error => {
        this.onError('Erro ao carregar clientes');
        return of([])
      })
    );
  }

  onError(errorMsg: string) {
    this.dialog.open(ErrorDialogComponent, {
      data: errorMsg
    });
  }

  ngOnInit(): void {
  }

  onAdd(){
    this.router.navigate(['new'], {relativeTo: this.route})
  }

  onEdit(customer: Customer){
    this.router.navigate(['edit', '1'], {relativeTo: this.route})
  }
}


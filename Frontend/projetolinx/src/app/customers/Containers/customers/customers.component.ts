import { Component, OnInit } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { MatSnackBar } from '@angular/material/snack-bar';
import { ActivatedRoute, Router } from '@angular/router';
import { catchError, Observable, of } from 'rxjs';
import { ConfirmationDialogComponent } from 'src/app/shared/components/confirmation-dialog/confirmation-dialog.component';
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
    private route: ActivatedRoute,
    private snackBar: MatSnackBar
  ) {
    this.customers$ = this.listAllCustomers();
  }

  refresh() {
    this.listAllCustomers();
  }

  onError(errorMsg: string) {
    this.dialog.open(ErrorDialogComponent,
      {
        data: errorMsg
      });
  }

  ngOnInit(): void {
  }

  onAdd() {
    this.router.navigate(['new'], { relativeTo: this.route })
  }

  onEdit(customer: Customer) {
    this.router.navigate(['edit', customer.customerId], { relativeTo: this.route })
  }

  onRemove(customer: Customer) {

    const dialogRef = this.dialog.open(ConfirmationDialogComponent, {
      data: 'Deseja excluir cliente?',
    });

    dialogRef.afterClosed().subscribe((result: boolean) => {
      if (result) {
        this.customerService.remove(customer.customerId)
          .subscribe(
            () => {
              this.refresh();
              this.snackBar.open('cliente removido com sucesso.', 'X', {
                duration: 5000,
                verticalPosition: 'top',
                horizontalPosition: 'center'
              })
            },
            () => this.onError('Error ao tentar remover cliente.')
          );
      }
    });
  }

  private listAllCustomers(): Observable<Customer[]> {
    return this.customerService.listCustomers()
      .pipe(
        catchError(() => {
          this.onError('Erro ao carregar clientes');
          return of([])
        })
      );
  }
}


import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { Customer } from '../../Models/customer';

@Component({
  selector: 'app-customers-list',
  templateUrl: './customers-list.component.html',
  styleUrls: ['./customers-list.component.scss']
})
export class CustomersListComponent implements OnInit {

  @Input() customers: Customer[] = [];
  @Output() add = new EventEmitter(false);
  @Output() edit = new EventEmitter(false);
  
  readonly displayedColumns = ['name', 'cpf', 'actions'];

  constructor() { }

  ngOnInit(): void {
  }

  onAdd(){
    this.add.emit(true);
  }

  onEdit(customer: Customer){
    this.edit.emit(customer);
  }
}

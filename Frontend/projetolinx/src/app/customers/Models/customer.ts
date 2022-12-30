import { Address } from "./address";

export interface Customer {
    customerId: string;
    name: string;
    cpf: string;
    addressDto: Address;
}

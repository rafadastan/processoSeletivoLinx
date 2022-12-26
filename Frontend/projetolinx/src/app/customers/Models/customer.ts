export class Customer {
    _id: string;
    name: string;
    cpf: string;

    constructor(_id: string, name: string, cpf: string) {
        this._id = _id;
        this.name =  name;
        this.cpf = cpf;
    }
}

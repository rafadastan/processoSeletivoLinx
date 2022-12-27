using SUC.Domain.Contracts.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation.Results;
using ProjetoLinx.Domain.Validations;

namespace ProjetoLinx.Domain.Entities
{
    public class Address : IBaseValidations
    {
        public Address(Guid addressId, 
            Guid customerId, 
            string street, 
            string city, 
            string state, 
            string neighborhood, 
            string number, 
            string cep)
        {
            AddressId = addressId;
            CustomerId = customerId;
            Street = street;
            City = city;
            State = state;
            Neighborhood = neighborhood;
            Number = number;
            Cep = cep;
        }

        public Guid AddressId { get; private set; }
        public Guid CustomerId { get; private set; }
        public string Street { get; private set; }
        public string City { get; private set; }
        public string State { get; private set; }
        public string Neighborhood { get; private set; }
        public string Number { get; private set; }
        public string Cep { get; private set; }

        public Customer Customer { get; set; }

        public ValidationResult Validate 
            => new AddressValidation().Validate(this);
    }
}

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
        public Guid AddressId { get; set; }
        public Guid CustomerId { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Neighborhood { get; set; }
        public string Number { get; set; }
        public string Cep { get; set; }

        public Customer Customer { get; set; }

        public ValidationResult Validate 
            => new AddressValidation().Validate(this);
    }
}

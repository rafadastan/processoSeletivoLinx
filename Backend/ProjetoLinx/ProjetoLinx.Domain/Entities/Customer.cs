using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation.Results;
using ProjetoLinx.Domain.Validations;
using SUC.Domain.Contracts.Base;

namespace ProjetoLinx.Domain.Entities
{
    public class Customer : IBaseValidations
    {
        public Guid CustomerId { get; set; }
        public string Name { get; set; }
        public string Cpf { get; set; }

        public Address Address { get; set; }

        public ValidationResult Validate =>
            new CustomerValidation().Validate(this);
    }
}

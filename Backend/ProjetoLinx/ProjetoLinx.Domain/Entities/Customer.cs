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
        public Customer(Guid customerId, 
            string name, 
            string cpf)
        {
            CustomerId = customerId;
            Name = name;
            Cpf = cpf;
        }

        public Guid CustomerId { get; private set; }
        public string Name { get; private set; }
        public string Cpf { get; private set; }

        public Address Address { get; set; }

        public ValidationResult Validate =>
            new CustomerValidation().Validate(this);
    }
}

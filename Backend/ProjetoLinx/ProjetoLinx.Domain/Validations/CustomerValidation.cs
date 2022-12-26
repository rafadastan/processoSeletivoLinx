using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjetoLinx.Domain.Entities;

namespace ProjetoLinx.Domain.Validations
{
    public class CustomerValidation : AbstractValidator<Customer>
    {
        public CustomerValidation()
        {
            RuleFor(c => c.CustomerId)
                .NotEmpty()
                .WithMessage("O id não pode ser nulo");

            RuleFor(c => c.Cpf)
                .NotEmpty()
                .WithMessage("O cpf não pode ser nulo");

            RuleFor(c => c.Name)
                .NotEmpty()
                .WithMessage("O nome não pode ser nulo");
        }
    }
}

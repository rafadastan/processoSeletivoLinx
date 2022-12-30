using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjetoLinx.Domain.Entities;

namespace ProjetoLinx.Domain.Validations
{
    public class AddressValidation : AbstractValidator<Address>
    {
        public AddressValidation()
        {
            //RuleFor(a => a.AddressId)
            //    .NotEmpty()
            //    .WithMessage("O Id não pode ser nulo");

            RuleFor(a => a.City)
                .NotEmpty()
                .WithMessage("Cidade não pode ser vazio");

            RuleFor(a => a.Neighborhood)
                .NotEmpty()
                .WithMessage("Bairro não pode ser vazio");

            RuleFor(a => a.Street)
                .NotEmpty()
                .WithMessage("Endereço não pode ser vazio");

            RuleFor(a => a.State)
                .NotEmpty()
                .WithMessage("Estado não pode ser vazio");
        }
    }
}

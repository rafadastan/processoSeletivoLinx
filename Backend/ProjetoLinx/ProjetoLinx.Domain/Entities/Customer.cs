using ProjetoLinx.Domain.Validations;
using SUC.Domain.Contracts.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ValidationResult = FluentValidation.Results.ValidationResult;

namespace ProjetoLinx.Domain.Entities
{
    public class Customer : IBaseValidations
    {
        public Guid CustomerId { get; internal set; }
        public string Name { get; internal set; }
        public string Cpf { get; internal set; }

        public virtual Address Address { get; set; }

        public ValidationResult Validate =>
            new CustomerValidation().Validate(this);
    }
}

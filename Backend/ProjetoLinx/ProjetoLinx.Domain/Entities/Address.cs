using SUC.Domain.Contracts.Base;
using System.ComponentModel.DataAnnotations;
using ProjetoLinx.Domain.Validations;
using ValidationResult = FluentValidation.Results.ValidationResult;

namespace ProjetoLinx.Domain.Entities
{
    public class Address : IBaseValidations
    {
        public Guid AddressId { get; internal set; }

        public string Street { get; internal set; }
        public string City { get; internal set; }
        public string State { get; internal set; }
        public string Neighborhood { get; internal set; }
        public string Number { get; internal set; }
        public string Cep { get; internal set; }

        public virtual Customer Customer { get; set; }

        public ValidationResult Validate 
            => new AddressValidation().Validate(this);
    }
}

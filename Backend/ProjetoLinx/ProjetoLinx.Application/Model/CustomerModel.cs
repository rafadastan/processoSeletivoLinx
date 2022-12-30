using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoLinx.Application.Model
{
    public class CustomerModel
    {
        [Required()]
        public string Name { get; set; }
        
        [Required()]
        public string Cpf { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Neighborhood { get; set; }
        public string Number { get; set; }
        public string Cep { get; set; }
    }
}

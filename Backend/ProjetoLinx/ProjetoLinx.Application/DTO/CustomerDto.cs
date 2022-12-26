using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoLinx.Application.DTO
{
    public class CustomerDto
    {
        public string Name { get; set; }
        public string Cpf { get; set; }

        public AddressDto AddressDto { get; set; }
    }
}

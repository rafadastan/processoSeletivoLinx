using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjetoLinx.Application.DTO;
using ProjetoLinx.Domain.Entities;

namespace ProjetoLinx.Application.Profile
{
    public class AddressProfile : AutoMapper.Profile
    {
        public AddressProfile()
        {
            CreateMap<AddressDto, Address>()
                .ReverseMap();
        }
    }
}

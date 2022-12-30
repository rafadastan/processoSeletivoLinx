using System.Xml.Serialization;
using ProjetoLinx.Application.DTO;
using ProjetoLinx.Application.Model;
using ProjetoLinx.Domain.Entities;

namespace ProjetoLinx.Application.Profile
{
    public class CustomerProfile : AutoMapper.Profile
    {
        public CustomerProfile()
        {
            CreateMap<CustomerDto, Customer>()
                .ForMember(dest => dest.Address,
                    opt => opt.MapFrom(src => src.AddressDto))
                .ForMember(
                    dest => dest.CustomerId,
                    opt => opt.MapFrom(src => src.CustomerId))
                .ReverseMap();
        }
    }
}

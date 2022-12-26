using System.Xml.Serialization;
using ProjetoLinx.Application.DTO;
using ProjetoLinx.Domain.Entities;

namespace ProjetoLinx.Application.Profile
{
    public class CustomerProfile : AutoMapper.Profile
    {
        public CustomerProfile()
        {
            //CreateMap<CustomerDto, Customer>()
            //    .ForMember(
            //        dest => dest.CustomerId,
            //        opt=> 
            //            opt.MapFrom(src => Guid.NewGuid())
            //        )
            //    .ForMember(dest => dest.Address,
            //        opt => opt.MapFrom(src => src.AddressDto))
            //    .ReverseMap();

            CreateMap<CustomerDto, Customer>()
                .ForMember(dest => dest.Address,
                    opt => opt.MapFrom(src => src.AddressDto))
                .ReverseMap();
        }
    }
}

using AutoMapper.Web.DTOs;
using FluentValidation.Web.Models;

namespace AutoMapper.Web.Mapping
{
    // Profile class comes from AutoMapper
    public class CustomerProfile : Profile
    {
        public CustomerProfile()
        {
            // ReverseMap => makes the opposite one too
            // CreateMap<Customer, CustomerDto>().ReverseMap();
            CreateMap<Customer, CustomerDto>()
                .ForMember(dest => dest.MyName, options => options.MapFrom(c => c.Name))
                .ForMember(dest => dest.MyEmail, options => options.MapFrom(c => c.Email))
                .ForMember(dest => dest.MyAge, options => options.MapFrom(c => c.Age));
            // CreateMap<CustomerDto, Customer>(); // converts customerdto to customer
        }
    }
}

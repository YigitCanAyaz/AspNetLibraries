using AutoMapper.Web.DTOs;
using AutoMapper.Web.Models;
using FluentValidation.Web.Models;

namespace AutoMapper.Web.Mapping
{
    // Profile class comes from AutoMapper
    public class CustomerProfile : Profile
    {
        public CustomerProfile()
        {
            CreateMap<CreditCard, CustomerDto>();

            // ReverseMap => makes the opposite one too
            // CreateMap<Customer, CustomerDto>().ReverseMap();
            // If properties have same name and using other classes like CreditCard, use IncludeMembers
            CreateMap<Customer, CustomerDto>().IncludeMembers(c => c.CreditCard)
                .ForMember(dest => dest.MyName, options => options.MapFrom(c => c.Name))
                .ForMember(dest => dest.MyEmail, options => options.MapFrom(c => c.Email))
                .ForMember(dest => dest.MyAge, options => options.MapFrom(c => c.Age))
                .ForMember(dest => dest.FullName, options => options.MapFrom(c => c.FullName2()));
                //.ForMember(dest => dest.CCNumber, options => options.MapFrom(c => c.CreditCard.Number))
                //.ForMember(dest => dest.CCValidDate, options => options.MapFrom(c => c.CreditCard.ValidDate));
            // CreateMap<CustomerDto, Customer>(); // converts customerdto to customer
        }
    }
}

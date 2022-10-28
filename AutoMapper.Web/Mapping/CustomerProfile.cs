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
            CreateMap<Customer, CustomerDto>().ReverseMap();
            // CreateMap<CustomerDto, Customer>(); // converts customerdto to customer
        }
    }
}

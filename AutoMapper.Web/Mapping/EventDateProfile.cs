using AutoMapper.Web.DTOs;
using AutoMapper.Web.Models;

namespace AutoMapper.Web.Mapping
{
    public class EventDateProfile : Profile
    {
        public EventDateProfile()
        {
            CreateMap<EventDateDto, EventDate>().ForMember(e => e.Date, options => options.MapFrom(e => new DateTime(e.Year, e.Month, e.Day)));
            CreateMap<EventDate, EventDateDto>()
                .ForMember(e => e.Year, options => options.MapFrom(e => e.Date.Year))
                .ForMember(e => e.Month, options => options.MapFrom(e => e.Date.Month))
                .ForMember(e => e.Day, options => options.MapFrom(e => e.Date.Day));
        }
    }
}

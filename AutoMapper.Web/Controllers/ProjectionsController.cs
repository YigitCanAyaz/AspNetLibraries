using AutoMapper.Web.DTOs;
using AutoMapper.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace AutoMapper.Web.Controllers
{
    public class ProjectionsController : Controller
    {
        private readonly IMapper _mapper;

        public ProjectionsController(IMapper mapper)
        {
            _mapper = mapper;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(EventDateDto eventDateDto)
        {
            EventDate eventDate = _mapper.Map<EventDate>(eventDateDto);

            ViewBag.date = eventDate.Date.ToShortDateString();

            return View();
        }
    }
}

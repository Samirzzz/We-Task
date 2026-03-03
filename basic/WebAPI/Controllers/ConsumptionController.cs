using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Hosting;
using System.IO;
using basic.Application.Services;
using basic.Domain.Interfaces;
using basic.WebAPI.MiddleWare.Filters;
using Microsoft.AspNetCore.Authorization;

namespace basic.WebAPI.Controllers{
    [ApiController]
    [Route("api/[controller]")]
    public class ConsumptionController : ControllerBase
    {
        private readonly IWebHostEnvironment _env;
        private readonly IConsumptionService _consumptionService;
        public ConsumptionController(IWebHostEnvironment env, IConsumptionService consumptionService)
        {
            _env = env;
            _consumptionService = consumptionService;
        }
        [HttpGet("getconsumption")]
        public IActionResult GetConsumption()
        {
           var filePath = Path.Combine(_env.ContentRootPath, "Data", "Consumption.xml");
           if(!System.IO.File.Exists(filePath))
           {
            return NotFound("XML file not found.");
           }
            var xmlContent = System.IO.File.ReadAllText(filePath);
            return Content(xmlContent, "application/xml");
        }
        [ServiceFilter(typeof(GroupRoleAuthFilter))]
        [HttpGet("parse-consumption")]
        public IActionResult ParseConsumption()
        {
            var filePath = Path.Combine(_env.ContentRootPath, "Data", "Consumption.xml");
            if(!System.IO.File.Exists(filePath))
            {
                return NotFound("XML file not found.");
            }
            var xmlContent = System.IO.File.ReadAllText(filePath);
            var dto = _consumptionService.ParseConsumption(xmlContent);
            return Ok(dto);
        }
    }
}
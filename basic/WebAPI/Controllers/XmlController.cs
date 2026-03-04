using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Hosting;
using System.IO;
using System.Xml.Linq;
using System.Linq;
using System.Collections.Generic;
using System;
using System.Globalization;   
using Application.DTOs;
using basic.Application.Services;
using basic.Domain.Interfaces;
using basic.WebAPI.MiddleWare.Filters;
namespace basic.WebAPI.Controllers
{
   
    [ApiController]
    [Route("api/[controller]")]
    public class XmlController : ControllerBase
    {
        private readonly IXmlService _xmlService;
        private readonly IWebHostEnvironment _env;

        public XmlController(IWebHostEnvironment env, IXmlService xmlService)
        {
            _env = env;
            _xmlService = xmlService;
        }

        [HttpGet("member-group")]
        public IActionResult GetMemberGroupXml()
        {
            var filePath = Path.Combine(_env.ContentRootPath, "Data", "MemberGroupResponse.xml");

            if (!System.IO.File.Exists(filePath))
            {
                return NotFound("XML file not found.");
            }

            var xmlContent = System.IO.File.ReadAllText(filePath);
            return Content(xmlContent, "application/xml");
        }
[ServiceFilter(typeof(GroupRoleAuthFilter))]
[HttpGet("parse-member-group")]
public IActionResult ParseMemberGroupXml()
{
var filepath=Path.Combine(_env.ContentRootPath, "Data", "MemberGroupResponse.xml");
if(!System.IO.File.Exists(filepath))
{
    return NotFound("XML file not found.");
}
var xmlContent=System.IO.File.ReadAllText(filepath);
var dto=_xmlService.ParseGroupResponse(xmlContent);
return Ok(dto);
}


    }
}


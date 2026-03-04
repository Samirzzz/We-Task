using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Hosting;
using System.IO;
using basic.Domain.Interfaces;
namespace basic.WebAPI.Controllers{
[ApiController]
[Route("api/[controller]")]
public class AvtController : ControllerBase{
    private readonly IAvtService _avtService;
    private readonly IWebHostEnvironment _env;
    public AvtController(IAvtService avtService, IWebHostEnvironment env){
        _avtService = avtService;
        _env = env;
    }
    [HttpGet("getfbb")]
    public IActionResult GetAvt(){
        var files=new[]{"Fbb1.xml", "Fbb2.xml", "Gsm1.xml", "Gsm2.xml"};
        var selectedFile=files[Random.Shared.Next(files.Length)];
        var filePath = Path.Combine(_env.ContentRootPath, "Data", selectedFile);
        if(!System.IO.File.Exists(filePath))
        {
            return NotFound("XML file not found.");
        }
        var xmlContent = System.IO.File.ReadAllText(filePath);
        if(selectedFile.Contains("Fbb"))
        {
            var dto = _avtService.GetFbb(xmlContent);
            return Ok(dto);
        }
        else
        {
            var dto = _avtService.GetGsm(xmlContent);
            return Ok(dto);
        }
    }
}
}
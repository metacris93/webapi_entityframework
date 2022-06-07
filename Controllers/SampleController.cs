using Microsoft.AspNetCore.Mvc;
using webapi.Services;

namespace webapi.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class SampleController : ControllerBase
  {
    ISampleService sampleService;
    private TareasContext dbContext;
    public SampleController(ISampleService sampleService, TareasContext dbContext)
    {
      this.sampleService = sampleService;
      this.dbContext = dbContext;
    }
    [HttpGet]
    public IActionResult Get()
    {
      return Ok(sampleService.GetHelloWorld());
    }
    [HttpGet]
    [Route("createdb")]
    public IActionResult CreateDatabase()
    {
      dbContext.Database.EnsureCreated();
      return Ok();
    }
  }
}
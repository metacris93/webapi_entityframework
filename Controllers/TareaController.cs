using Microsoft.AspNetCore.Mvc;
using webapi.Models;
using webapi.Services;

namespace webapi.Controllers;

[Route("api/[controller]")]
public class TareaController : ControllerBase
{
  private ITareasService tareasService;
  public TareaController(ITareasService tareasService)
  {
    this.tareasService = tareasService;
  }
  [HttpGet]
  public IActionResult Get()
  {
    return Ok(tareasService.Get());
  }
  [HttpPost]
  public async Task<IActionResult> Post([FromBody] Tarea tarea)
  {
    await tareasService.Save(tarea);
    return Ok();
  }

  [HttpPut("{id}")]
  public async Task<IActionResult> Put(Guid id, [FromBody] Tarea tarea)
  {
    await tareasService.Update(id, tarea);
    return Ok();
  }

  [HttpDelete("{id}")]
  public async Task<IActionResult> Delete(Guid id)
  {
    await tareasService.Delete(id);
    return Ok();
  }  
}
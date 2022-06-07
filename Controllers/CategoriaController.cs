using Microsoft.AspNetCore.Mvc;
using webapi.Models;
using webapi.Services;

namespace webapi.Controllers;

[Route("api/[controller]")]
public class CategoriaController : ControllerBase
{
  private ICategoriasService categoriaService;

  public CategoriaController(ICategoriasService categoriaService)
  {
    this.categoriaService = categoriaService;
  }

  [HttpGet]
  public IActionResult Get()
  {
    return Ok(categoriaService.Get());
  }

  [HttpPost]
  public async Task<IActionResult> Post([FromBody] Categoria categoria)
  {
    await categoriaService.Save(categoria);
    return Ok();
  }

  [HttpPut("{id}")]
  public async Task<IActionResult> Put(Guid id, [FromBody] Categoria categoria)
  {
    await categoriaService.Update(id, categoria);
    return Ok();
  }

  [HttpDelete("{id}")]
  public async Task<IActionResult> Delete(Guid id)
  {
    await categoriaService.Delete(id);
    return Ok();
  }
}
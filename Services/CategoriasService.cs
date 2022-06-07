using webapi.Models;

namespace webapi.Services;

public class CategoriasService : ICategoriasService
{
  private TareasContext context;

  public CategoriasService(TareasContext dbContext)
  {
    context = dbContext;
  }
  public IEnumerable<Categoria> Get()
  {
    return context.Categorias;
  }
  public async Task Save(Categoria categoria)
  {
    context.Add(categoria);
    await context.SaveChangesAsync();
  }
  public async Task Update(Guid id, Categoria categoria)
  {
    var currentCategory = await context.Categorias.FindAsync(id);
    if (currentCategory == null) return;

    currentCategory.Nombre = categoria.Nombre;
    currentCategory.Descripcion = categoria.Descripcion;
    currentCategory.Peso = categoria.Peso;
    await context.SaveChangesAsync();
  }
  public async Task Delete(Guid id)
  {
    var currentCategory = await context.Categorias.FindAsync(id);
    if (currentCategory == null) return;

    context.Categorias.Remove(currentCategory);
    await context.SaveChangesAsync();
  }
}

public interface ICategoriasService
{
  IEnumerable<Categoria> Get();
  Task Save(Categoria categoria);
  Task Update(Guid id, Categoria categoria);
  Task Delete(Guid id);
}

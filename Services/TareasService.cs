using webapi.Models;

namespace webapi.Services;

public class TareasService : ITareasService
{
  private TareasContext context;

  public TareasService(TareasContext dbContext)
  {
    context = dbContext;
  }
  public IEnumerable<Tarea> Get()
  {
    return context.Tareas;
  }

  public async Task Save(Tarea tarea)
  {
    context.Add(tarea);
    await context.SaveChangesAsync();
  }

  public async Task Update(Guid id, Tarea tarea)
  {
    var currentTarea = await context.Tareas.FindAsync(id);
    if (currentTarea == null) return;

    currentTarea.Titulo = tarea.Titulo;
    currentTarea.Descripcion = tarea.Descripcion;
    currentTarea.PrioridadTarea = tarea.PrioridadTarea;
    await context.SaveChangesAsync();
  }

  public async Task Delete(Guid id)
  {
    var currentTarea = await context.Tareas.FindAsync(id);
    if (currentTarea == null) return;

    context.Tareas.Remove(currentTarea);
    await context.SaveChangesAsync();
  }
}

public interface ITareasService
{
  IEnumerable<Tarea> Get();
  Task Save(Tarea tarea);
  Task Update(Guid id, Tarea tarea);
  Task Delete(Guid id);
}
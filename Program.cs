using Microsoft.EntityFrameworkCore;
using webapi;
using webapi.Middlewares;
using webapi.Services;

AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
// builder.Services.AddDbContext<TaskContext>(p => p.UseInMemoryDatabase("TasksDB"));
builder.Services.AddDbContext<TareasContext>(p => p.UseNpgsql(connectionString));

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//esto debe ocurrir antes de hacer builder.Build()
builder.Services.AddScoped<ISampleService, SampleService>();
builder.Services.AddScoped<ICategoriasService, CategoriasService>();
builder.Services.AddScoped<ITareasService, TareasService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

// app.UseWelcomePage();
// app.UseTimeMiddleware();

app.MapControllers();

app.Run();

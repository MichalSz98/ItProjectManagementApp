using Application.CQRS.Handlers;
using Domain.Repositories;
using Infrastructure.Data;
using ItProjectManagementApp;
using ItProjectManagementApp.Middleware;
using NLog.Web;

var builder = WebApplication.CreateBuilder(args);
builder.Host.UseNLog();

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddDbContext<ApplicationContext>();
builder.Services.AddScoped<ProjectSeeder>();
builder.Services.AddAutoMapper(typeof(Program).Assembly);
builder.Services.AddScoped<ErrorHandlingMiddleware>();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IProjectRepository, EfProjectRepository>();
builder.Services.AddScoped<ITaskRepository, EfProjectRepository2>();
builder.Services.AddScoped<GetAllProjectsQueryHandler>();
builder.Services.AddScoped<CreateProjectCommandHandler>();
builder.Services.AddScoped<CreateTaskCommandHandler>();

var app = builder.Build();

// Seed the database
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;

    try
    {
        var seeder = services.GetRequiredService<ProjectSeeder>();
        seeder.Seed();
    }
    catch (Exception ex)
    {
        var logger = services.GetRequiredService<ILogger<Program>>();
        logger.LogError(ex, "An error occurred seeding the DB.");
    }
}

app.UseMiddleware<ErrorHandlingMiddleware>();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "ItProjectManagementApp");
});

app.UseAuthorization();

app.MapControllers();

app.Run();

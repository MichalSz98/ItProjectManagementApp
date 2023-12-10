using Application.CQRS.Handlers;
using Application.CQRS.Queries;
using Application.Hexagonal.Services;
using Application.Onion.Services;
using Domain.Ports;
using Domain.Repositories;
using Infrastructure.Data;
using Infrastructure.Services;
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
builder.Services.AddScoped(typeof(IDataRepository<>), typeof(EfGenericRepository<>));

builder.Services.AddScoped<GetAllProjectsQueryHandler>();
builder.Services.AddScoped<CreateProjectCommandHandler>();

builder.Services.AddScoped<CreateTaskCommandHandler>();

builder.Services.AddScoped<AddCommentCommandHandler>();
builder.Services.AddScoped<GetTaskCommentsQueryHandler>();

builder.Services.AddScoped<GenericHandler>();
builder.Services.AddScoped<INotificationService, EmailNotificationService>();
builder.Services.AddScoped<TaskAssignmentService>();
builder.Services.AddScoped<TaskDependencyService>();

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

using Microsoft.EntityFrameworkCore;
using Scrum.Infraestructure.MainContext;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

builder.Configuration
    .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
    .AddJsonFile($"appsettings.{builder.Environment.EnvironmentName}.json", optional: true, reloadOnChange: true)
    .AddEnvironmentVariables();

builder.Logging.ClearProviders();
builder.Logging.AddConsole();
builder.Logging.AddFile(o => o.RootPath = o.RootPath = @"C:\Scrum_Logs");

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


builder.Services.AddCors(options =>
{
    options.AddPolicy("ISCPolicy", policy =>
    {
        policy.AllowAnyOrigin()
        .AllowAnyMethod()
        .AllowAnyHeader();
    });
});


builder.Services.AddDbContext<ScrumManagementContext>(options =>
        options.UseSqlServer(builder.Configuration.GetConnectionString("conexion")));

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

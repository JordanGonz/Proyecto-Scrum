using Microsoft.EntityFrameworkCore;
using Scrum.Infraestructure.MainContext;
using AutoMapper;
using Scrum.Infraestructure.Mappers;
using Scrum.Core.Contracts.Middleware;
using Scrum.Core.Common;

var builder = WebApplication.CreateBuilder(args);


builder.Configuration
    .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
    .AddJsonFile($"appsettings.{builder.Environment.EnvironmentName}.json", optional: true, reloadOnChange: true)
    .AddEnvironmentVariables();

builder.Logging.ClearProviders();
builder.Logging.AddConsole();
builder.Logging.AddFile(o => o.RootPath = o.RootPath = @"C:\Scrum_Logs");


builder.Services.AddCors(options =>
{
    options.AddPolicy("ISCPolicy", policy =>
    {
        policy.AllowAnyOrigin()
        .AllowAnyMethod()
        .AllowAnyHeader();
    });
});




builder.Services.AddAutoMapper(
    typeof(ComentariosProfile)
);


builder.Services.AddDbContext<ScrumManagementContext>(options =>
        options.UseSqlServer(builder.Configuration.GetConnectionString("ScrumDb")));



builder.Services.AddHttpContextAccessor();

builder.Services.AddTransient<IExceptionHandler, GenericExceptionHandler>();

builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();


builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
var app = builder.Build();


if (app.Environment.IsProduction())
{

}
app.Use(async (context, next) =>
{
    Console.WriteLine($"Request: {context.Request.Path}");
    await next();
});
app.UseCors("ISCPolicy");
app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "API Integrity Project Management v1.0");

});

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

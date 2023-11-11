using Framework.Autofac;
using Framework.EntityFrameworkCore;
using Framework.RestApi.Conventions;
using ServiceHost.Documentations;
using ServiceHost.Extensions;
using ServiceHost.Helpers;

var builder = WebApplication.CreateBuilder(args);
var config = builder.Configuration.GetSection("Config").Get<BaseConfig>();
builder.AddAutofac(args,config);
builder.AddDatabase();

// Add services to the container.

builder.Services.AddControllers(a =>
{
    a.Conventions.Add(new CqrsModelConvention());
});
builder.AddApiVersioning();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.AddAllCors();
builder.Services.AddSwaggerGen();

builder.AddSwagger();

builder.Services.ConfigureOptions<ConfigureSwaggerOptions>();
var app = builder.Build();

// Configure the HTTP request pipeline.
// if (app.Environment.IsDevelopment())
// {
app.UseSwaggerWithVersioning();
// }
app.UseHttpsRedirection();

app.UseCors();

app.MapControllers();
app.ConfigureExceptionHandling(new ExceptionLoggerRepository(), config);
app.Run();

















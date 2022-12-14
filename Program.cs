using back_end;
using back_end.Controllers;
using back_end.repositorios;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.DataProtection.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddSingleton<IRepositorio, RepositorioEnMemoria>();
builder.Services.AddScoped<WeatherForecastController>();
builder.Services.AddControllers();
// builder.Services.AddTransient<IRepositorio, RepositorioEnMemoria>();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
app.Use(async (context, next) =>
{
    using (var swapStream =  new MemoryStream())
    {
        var respuestaOriginal = context.Response.Body;
        context.Response.Body = swapStream;

        await next.Invoke();

        swapStream.Seek(0, SeekOrigin.Begin);
        string respuesta = new StreamReader(swapStream).ReadToEnd();
        swapStream.Seek(0,SeekOrigin.Begin);

        await swapStream.CopyToAsync(respuestaOriginal);
        context.Response.Body = respuestaOriginal;

        app.Logger.LogInformation(respuesta);

    }
});

app.Map("/mapa1", (app) =>
{
    app.Run(async context =>
    {
        await context.Response.WriteAsync("Estoy interceptando el pipeline");
    });
});



if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

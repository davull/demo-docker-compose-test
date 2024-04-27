using Demo_TestContainers.Endpoints;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapGet("/products", ProductsEndpoints.Get)
    .WithOpenApi();

app.MapGet("/products/{sku}", ProductsEndpoints.GetBySku)
    .WithOpenApi();

app.Run();

public partial class Program;
using ProductManagement.Infrastructure.Extensions;
using ProductManagement.WebApi.Middleware;
using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers(options=>
{
    options.SuppressAsyncSuffixInActionNames = false;
});
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowMvcApp", policy =>
    {
        policy.WithOrigins("https://localhost:7245", "http://localhost:5050")
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
}); 
builder.Services.AddInfrastureDI(builder.Configuration);

builder.Services.AddMediatR(config =>
config.RegisterServicesFromAssemblies(typeof(ProductManagement.Application.Features.Products.Command.CreateProduct.CreateProductCommand).Assembly));

var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.MapScalarApiReference();
}
app.UseMiddleware<ExceptionHandlingMiddleware>();

app.UseMiddleware<RequestLoggingMiddleware>();

app.UseHttpsRedirection();

app.UseRouting();

app.UseStaticFiles();

app.UseCors("AllowMvcApp");

app.UseAuthorization();

app.MapControllers();

app.Run();

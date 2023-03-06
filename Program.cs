
using MyMicroservice.Data;
using MyMicroservice.Repositories;
using MediatR;
using System.Reflection;
using MyMicroservice.Utility;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddMediatR(Assembly.GetExecutingAssembly());

builder.Services.AddDbContext<DbContextClass>();
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<IStockRepository, StockRepository>();
builder.Services.AddScoped<ICustomerRepository, CustomerRepository>();
builder.Services.AddScoped<ISaleRepository, SaleRepository>();
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(
        policy =>
        {
            policy.WithOrigins("*");
        });
});

builder.Services.AddControllers().AddNewtonsoftJson();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();


if (app.Environment.IsDevelopment())
{   
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseMiddleware(typeof(GlobalErrorHandlingMiddleware));
app.UseHttpsRedirection();
app.UseCors();
app.UseAuthorization();

app.MapControllers();

app.Run();

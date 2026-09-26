using Application.Repository;
using Application.Service.CompanyService;
using Application.Service.OrderDetailServices;
using Application.Service.OrderDetailService.OrderDetailService;
using Application.Service.OrderServices;
using Application.Service.ProductServices;
using Application.Service.UserSrvice;
using Infrastructure.Context;
using Infrastructure.Data;
using Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Application.Service.OrderService.OrderService;
using Application.Service.ProductService.ProductService;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddDbContext<AppDbContext>(option => option.UseSqlServer(builder.Configuration.GetConnectionString("Default")));

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "IMS APIs",
        Version = "v1",
    });
});
builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepositories<>));
builder.Services.AddScoped(typeof(IUserService), typeof(UserService));
builder.Services.AddScoped(typeof(IOrderDetailService), typeof(OrderDetailService));
builder.Services.AddScoped(typeof(IOrderService), typeof(OrderService));
builder.Services.AddScoped(typeof(ICompanyService), typeof(CompanyService));
builder.Services.AddScoped(typeof(IProductService), typeof(ProductService));


var app = builder.Build();
UserSeedData.UserSeed(app.Services);
app.UseSwagger();
app.UseSwaggerUI();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

using Microsoft.EntityFrameworkCore;
using RestaurantManagement.Api.AutoMappers;
using RestaurantManagement.Data.DataContext;
using RestaurantManagement.Data.Entities;
using RestaurantManagement.Data.Repository;
using RestaurantManagement.Data.Repository.Interfaces;
using RestaurantManagement.Services.Interfaces;
using RestaurantManagement.Services.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContextPool<RestaurantContext>(opt =>
    opt.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddHttpClient();
builder.Services.AddTransient<IUserService, UserService>();
builder.Services.AddTransient<IProductService, ProductService>();
builder.Services.AddTransient<IMenuService, MenuService>();
builder.Services.AddTransient<IOrderService, OrderService>();
builder.Services.AddTransient<ICategoryService, CategoryService>();
builder.Services.AddTransient<IGenericRepository<User>, GenericRepository<User>>();
builder.Services.AddTransient<IGenericRepository<Product>, GenericRepository<Product>>();
builder.Services.AddTransient<IGenericRepository<Menu>, GenericRepository<Menu>>();
builder.Services.AddTransient<IGenericRepository<Order>, GenericRepository<Order>>();
builder.Services.AddTransient<IGenericRepository<Category>, GenericRepository<Category>>();
builder.Services.AddAutoMapper(typeof(AutoMapperProfile));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

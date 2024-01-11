using Microsoft.EntityFrameworkCore;
using Shop.Aplication.Repository;
using Shop.Aplication.Services.ProductCategoryService;
using Shop.Aplication.Services.ProductService;
using Shop.Domain.Repositories;
using Shop.Infrastructure;
using Shop.Infrastructure.Data;
using Shop.Infrastructure.Repositories;
using Shop.Aplication.Services.ProductCartService;
using Shop.Aplication.Services.OrderService;
using Shop.Middlewear;
using Shop.Domain.Transaction;
using Shop.Infrastructure.Transaction;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Shop.Aplication.Services.UserService;
using System.Text;
using Microsoft.AspNetCore.Authentication.Cookies;
using Shop.Aplication.Services.SessionService;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AplicationDbContext>(option =>
{
    option.UseSqlServer(builder.Configuration.GetConnectionString("DefaultSQLConnection"));
});
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<IProductCategoryRepository, ProductCategoryRepository>();
builder.Services.AddScoped<IProductCategoryService, ProductCategoryService>();
builder.Services.AddScoped<IProductReadonlyRepository, ProductReadonlyRepository>();
builder.Services.AddScoped<IProductCartService, ProductCartService>();
builder.Services.AddScoped<ICartRepository, CartRepository>();
builder.Services.AddScoped<IOrderService, OrderService>();
builder.Services.AddScoped<IOrdersRepository, OrdersRepository>();
builder.Services.AddScoped<ITransaction, Transactions>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<ICookieRepository, CookieRepository>();
builder.Services.AddScoped<ISessionService, SessionService>();
builder.Services.AddTransient<SessionMiddleware>();
builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddHttpContextAccessor();

var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.UseMiddleware<ExceptionHandlingMiddleware>();

app.UseMiddleware<SessionMiddleware>();

app.MapControllers();

app.Run();



using AwesomeShopPatterns.API.Application;
using AwesomeShopPatterns.API.Application.Mediator;
using AwesomeShopPatterns.API.Application.Observers;
using AwesomeShopPatterns.API.Infrastructure;
using AwesomeShopPatterns.API.Infrastructure.Payments;
using AwesomeShopPatterns.API.Infrastructure.Payments.Strategies;
using AwesomeShopPatterns.API.Infrastructure.Products;
using AwesomeShopPatterns.API.Infrastructure.Proxies;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddMemoryCache();
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<IPaymentFraudCheckService, PaymentFraudCheckService>();
builder.Services.AddScoped<ICustomerRepository, CustomerRepository>();

builder.Services.AddScoped<CustomerRepositoryProxy>();

builder.Services.AddSingleton<PaymentMethodsFactory>();

builder.Services.AddScoped<ICqrsMediator, CqrsMediator>();

builder.Services.AddSingleton<IDealsObserver, MarketingCampaignObserver>();
builder.Services.AddSingleton<IDealsObserver, WebsiteCatalogObserver>();
builder.Services.AddSingleton<IDealsSubject, DealsSubject>();

builder.Services.AddScoped<IPaymentContext, PaymentContext>();
builder.Services.AddScoped<IPaymentStrategyFactory, PaymentStrategyFactory>();

builder.Services.AddControllers();

builder.Services.AddHttpContextAccessor();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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

using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using SalesApi.Application.Products.Commands;
using SalesApi.Application.Products.Validators;
using SalesApi.Application.Sales.Commands;
using SalesApi.Application.Sales.Handlers;
using SalesApi.Application.Sales.Validators;
using SalesApi.Domain.Repositories;
using SalesApi.Infrastructure.Repositories;

namespace SalesApi.Infrastructure.Extensions
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblyContaining<CreateSaleCommandHandler>());
            services.AddScoped<IValidator<CreateSaleCommand>, CreateSaleCommandValidator>();

            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            services.AddScoped<ISaleRepository, SaleRepository>();
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IValidator<CreateSaleCommand>, CreateSaleCommandValidator>();
            services.AddScoped<IValidator<CreateProductCommand>, CreateProductCommandValidator>();


            return services;
        }
    }
}

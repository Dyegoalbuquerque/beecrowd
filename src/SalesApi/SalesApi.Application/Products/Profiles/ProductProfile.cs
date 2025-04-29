using AutoMapper;
using SalesApi.Application.Products.Commands;
using SalesApi.Domain.Entities;

namespace SalesApi.Application.Products.Profiles;

public class ProductProfile : Profile
{
    public ProductProfile()
    {
        CreateMap<CreateProductCommand, Product>();
    }
}

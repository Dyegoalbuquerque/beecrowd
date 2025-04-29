using AutoMapper;
using SalesApi.Application.Sales.Commands;
using SalesApi.Domain.Entities;

namespace SalesApi.Application.Sales.Profiles;

public class SaleProfile : Profile
{
    public SaleProfile()
    {
        CreateMap<CreateSaleCommand, Sale>();
        CreateMap<CreateSaleItemCommand, SaleItem>();
    }
}

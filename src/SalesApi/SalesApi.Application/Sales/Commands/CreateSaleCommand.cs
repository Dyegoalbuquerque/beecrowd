using MediatR;
using SalesApi.Application.Common;
using SalesApi.Domain.Entities;

namespace SalesApi.Application.Sales.Commands
{
    public class CreateSaleCommand : IRequest<HandlerResult<Sale>>
    {
        public string SaleNumber { get; set; } 
        public DateTime SaleDate { get; set; }
        public string CustomerId { get; set; }    
        public string BranchId { get; set; }
        public List<CreateSaleItemCommand> Items { get; set; } = new List<CreateSaleItemCommand>();
    }
}
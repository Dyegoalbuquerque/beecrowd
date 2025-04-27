using MediatR;
using SalesApi.Application.Common;
using SalesApi.Domain.Entities;

namespace SalesApi.Application.Sales.Commands
{
    public class CreateSaleCommand : IRequest<HandlerResult<Sale>>
    {
        public string CustomerId { get; set; }
        public string CustomerName { get; set; } = string.Empty;        
        public string BranchId { get; set; }
        public string Branch { get; set; } = string.Empty;
        public List<CreateSaleItemCommand> Items { get; set; } = new List<CreateSaleItemCommand>();
    }
}
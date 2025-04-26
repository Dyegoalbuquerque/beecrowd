namespace SalesApi.Domain.Entities
{
    public class Sale
    {
        public Sale()
        {
            Id = Guid.NewGuid();
            Nummber = $"S-{DateTime.UtcNow:yyyyMMddHHmmss}-{Guid.NewGuid().ToString()[..8]}";
            Date = DateTime.UtcNow;
        }

        public Guid Id { get; set; }
        public string Nummber { get; set; }
        public Guid CustomerId { get; set; }
        public string CustomerName { get; set; }
        public DateTime Date { get; set; }
        public decimal TaxValue { get; private set; }
        public decimal TotalAmount { get; set; }
        public string Branch { get; set; }
        public Guid BranchId { get; set; }
        public bool IsCancelled { get; set; }
        public List<SaleItem> Items { get; set; } = new();

        private int GetNumberOfIdenticalItems() => Items.GroupBy(i => i.ProductId).Select(g => g.Sum(i => i.Quantity)).DefaultIfEmpty(0).Max();
       
        public void CalculateSale()
        {
            var numberIdenticals = GetNumberOfIdenticalItems();
            
            TaxValue = numberIdenticals switch
            {
                >= 10 and <= 20 => 20m, // IVA Special
                > 4 and < 10 => 10m,    // IVA Normal
                _ => 0m                 // Free of IVA
            };

            var totalAmountItems = Items.Sum(i => i.TotalAmount);
            TotalAmount = totalAmountItems + (totalAmountItems * (TaxValue / 100));
        }
       
        public void Cancel() => IsCancelled = true;
    }
}

namespace SalesApi.Domain.Entities
{
    public class Sale
    {
        public Sale()
        {
            Id = Guid.NewGuid();
            SaleNummber = $"S-{DateTime.UtcNow:yyyyMMddHHmmss}-{Guid.NewGuid().ToString()[..8]}";
            SaleDate = DateTime.UtcNow;
        }

        public Guid Id { get; set; }
        public string SaleNummber { get; set; }
        public Guid CustomerId { get; set; }
        public DateTime SaleDate { get; set; }
        public decimal TotalAmount { get; set; }
        public Guid BranchId { get; set; }
        public bool IsCancelled { get; set; }
        public List<SaleItem> Items { get; set; } = new();
        
        public void Cancel() => IsCancelled = true;
        public void CalculateSale() => TotalAmount = Items.Sum(i => i.Total);
    }
}

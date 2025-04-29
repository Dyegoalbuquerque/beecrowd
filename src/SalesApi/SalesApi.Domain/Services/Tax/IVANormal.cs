namespace SalesApi.Domain.Services.Tax;
public class IVANormal : ITax
{
    public decimal CalculateTax(decimal amount)
    {
        return amount * 0.1m;
    }
}


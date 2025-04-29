namespace SalesApi.Domain.Services.Tax;

public class IVASpecial : ITax
{
    public decimal CalculateTax(decimal amount)
    {
        return amount * 0.2m;
    }
}


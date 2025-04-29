namespace SalesApi.Domain.Services.Tax;

public class IVAFree : ITax
{
    public decimal CalculateTax(decimal amount)
    {
        return 0m;
    }
}


namespace SalesApi.Domain.Services.Tax;

public static class IVAFactory
{
    public static ITax CreateTax(decimal Quantity)
    {
        return Quantity switch
        {
            >= 10 and <= 20 => new IVASpecial(),
            > 4 and < 10 => new IVANormal(),
            _ => new IVAFree(),
        };
    }
}


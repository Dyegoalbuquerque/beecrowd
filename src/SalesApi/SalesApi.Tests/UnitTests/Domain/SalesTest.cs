using SalesApi.Tests.Data.Sales;

namespace SalesApi.Tests.UnitTests.Domain;

public class SalesTest
{
    [Fact(DisplayName = "Sale above 4 identical items should apply 10% IVA")]
    public void Given_Sale_with4IdenticalsItems_When_ApplyTax_Then_ShouldHave10Percent()
    {
        var sale = SaleFaker.GetSaleFaker(5).Generate();
        var productIdIdentical = Guid.NewGuid();
        sale.Items.ForEach(item => { item.ProductId = productIdIdentical; item.Quantity = 1; });

        sale.CalculateSale();

        Assert.Equal(10m, sale.TaxValue);
    }

    [Fact(DisplayName = "Sale between 10 and 20 identical items have a 20% IVA")]
    public void Given_Sale_Between10and20Identical_When_ApplyTax_Then_ShouldHave20Percent()
    {
        var sale = SaleFaker.GetSaleFaker(12).Generate();
        var productIdIdentical = Guid.NewGuid();
        sale.Items.ForEach(item => { item.ProductId = productIdIdentical; item.Quantity = 1; });

        sale.CalculateSale();

        Assert.Equal(20m, sale.TaxValue);
    }

    [Fact(DisplayName = "Sale below 4 items cannot have a IVA")]
    public void Given_Sale_Below4items_When_CannotHaveIVA_Then_Free_Tax()
    {
        var sale = SaleFaker.GetSaleFaker(3).Generate();
        var productIdIdentical = Guid.NewGuid();
        sale.Items.ForEach(item => { item.ProductId = productIdIdentical; item.Quantity = 1; });

        sale.CalculateSale();

        Assert.Equal(0m, sale.TaxValue);
    }
}

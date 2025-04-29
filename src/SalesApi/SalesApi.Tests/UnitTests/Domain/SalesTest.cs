using SalesApi.Tests.Data.Sales;

namespace SalesApi.Tests.UnitTests.Domain;

public class SalesTest
{
    [Fact(DisplayName = "Sale above 4 identical items should apply 10% IVA")]
    public void Given_Sale_with4IdenticalsItems_When_ApplyTax_Then_ShouldHave10Percent()
    {
        var sale = SaleFaker.GetSaleFaker(5, 5).Generate();
      
        sale.CalculateSale();

        sale.Items.ToList()
                  .ForEach(item =>
                  {
                     var iva = item.ValueMonetaryTaxApplied / item.TotalWithoutTax; 

                     Assert.Equal(0.10m, iva, precision: 2);
                  });
    }

    [Fact(DisplayName = "Sale between 10 and 20 identical items have a 20% IVA")]
    public void Given_Sale_Between10and20Identical_When_ApplyTax_Then_ShouldHave20Percent()
    {
        var sale = SaleFaker.GetSaleFaker(5, 12).Generate();

        sale.CalculateSale();
        sale.Items.ToList()
                  .ForEach(item =>
                  {
                      var iva = item.ValueMonetaryTaxApplied / item.TotalWithoutTax;

                      Assert.Equal(0.20m, iva, precision: 2);
                  });
    }

    [Fact(DisplayName = "Sale below 4 items cannot have a IVA")]
    public void Given_Sale_Below4items_When_CannotHaveIVA_Then_Free_Tax()
    {
        var sale = SaleFaker.GetSaleFaker(5, 3).Generate();

        sale.CalculateSale();
        sale.Items.ToList()
                  .ForEach(item =>
                  {
                      var iva = item.ValueMonetaryTaxApplied / item.TotalWithoutTax;

                      Assert.Equal(0m, iva, precision: 2);
                  });
    }
}

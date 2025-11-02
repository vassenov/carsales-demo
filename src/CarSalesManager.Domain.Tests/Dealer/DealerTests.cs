using AutoFixture.Xunit2;
using FluentAssertions;

namespace CarSalesManager.Domain.Tests;

public class DealerTests
{
    [Theory]
    [InlineAutoData(null)]
    [InlineAutoData("")]
    public void Contructor_WithNullOrEmptyNameParameter_ThrowsException(string name, Address address)
    {
        //act, assert
        Assert.Throws<InvalidDealerException>(() => new Dealer(name, address));
    }

    [Theory]
    [InlineAutoData("test-name", null)]
    public void Contructor_WithNullAddressParameter_ThrowsException(string name, Address address)
    {
        //act, assert
        Assert.Throws<InvalidDealerException>(() => new Dealer(name, address));
    }

    [Theory]
    [InlineAutoData("test-name")]
    public void Contructor_WithValidParameters_ExpectedFlow(string name, Address address)
    {
        //act
        var dealer = new Dealer(name, address);

        //assert
        dealer.Name.Should().Be(name);
        dealer.Address.Should().Be(address);
        dealer.CarSales.Should().HaveCount(0);
    }

    [Theory]
    [InlineAutoData("test-name")]
    public void AddCarSale_WithNullParameter_ThrowsException(string name, Address address)
    {
        //arrange
        var dealer = new Dealer(name, address);
        
        //act, assert
        Assert.Throws<InvalidDealerException>(() => dealer.AddCarSale(null!));
    }

    [Theory]
    [InlineAutoData(12500, "test-name")]
    public void AddCarSale_WithValidParameter_ExpectedFlow(decimal amount, string name, Address address)
    {
        //arrange
        var dealer = new Dealer(name, address);
        var carSale = new CarSale(Manufacturer.LandRover, Transmission.Automatic, amount);

        //act
        dealer.AddCarSale(carSale);

        //assert
        dealer.CarSales.Should().HaveCount(1);
        dealer.CarSales.First().Should().Be(carSale);
    }
}

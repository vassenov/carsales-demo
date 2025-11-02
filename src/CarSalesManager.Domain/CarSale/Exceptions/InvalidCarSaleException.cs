using CarSalesManager.Domain.Abstractions;

namespace CarSalesManager.Domain;

public class InvalidCarSaleException : DomainException
{
    public InvalidCarSaleException()
    { 
    }

    public InvalidCarSaleException(string error)
        : base(error)
    {
    }
}

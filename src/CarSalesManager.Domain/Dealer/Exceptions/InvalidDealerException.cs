using CarSalesManager.Domain.Abstractions;

namespace CarSalesManager.Domain;

public class InvalidDealerException : DomainException
{
    public InvalidDealerException()
    {
    }

    public InvalidDealerException(string error)
        => Error = error;
}

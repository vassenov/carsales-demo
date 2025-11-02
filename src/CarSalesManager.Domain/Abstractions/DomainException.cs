namespace CarSalesManager.Domain.Abstractions;

public abstract class DomainException : Exception
{
    private string _error = default!;

    public DomainException()
    {
    }

    public DomainException(string message)
        : base(message)
        => Error = message;

    public string Error
    {
        get => _error ?? base.Message;
        set => _error = value;
    }
}

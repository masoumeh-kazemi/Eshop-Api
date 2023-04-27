namespace Common.Domain.Exeptions;

public class BaseDomainException : Exception
{
    public BaseDomainException()
    {

    }

    public BaseDomainException(string message) : base(message)
    {

    }
}
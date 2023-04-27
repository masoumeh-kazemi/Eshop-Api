namespace Common.Domain.Exeptions;

public class InvalidDomainDataException : BaseDomainException
{
    public InvalidDomainDataException()
    {

    }

    public InvalidDomainDataException(string message) : base(message)
    {

    }
}
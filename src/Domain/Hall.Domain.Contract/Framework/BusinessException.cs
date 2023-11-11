namespace Framework.Domain;

public class BusinessException : Exception
{
    public int Code { get; set; }

    public BusinessException(string message, int errorCode)
        : base(message)
    {
        this.Code = errorCode;
    }
}
namespace Framework.Domain;


public class ExceptionLogModel
{
    public long Id { get; set; }

    public string ApplicationName { get; set; }

    public DateTime DateTime { get; set; }

    public string ExceptionMessage { get; set; }

    public string Stacktrace { get; set; }

    public ExceptionLogModel(string applicationName, string exceptionMessage, string stacktrace)
    {
        this.ApplicationName = applicationName;
        this.DateTime = DateTime.Now;
        this.ExceptionMessage = exceptionMessage;
        this.Stacktrace = stacktrace;
    }

    protected ExceptionLogModel()
    {
    }
}
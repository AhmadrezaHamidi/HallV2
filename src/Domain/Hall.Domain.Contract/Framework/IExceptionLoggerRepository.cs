namespace Framework.Domain;

public interface IExceptionLoggerRepository
{
    Task Save(ExceptionLogModel exceptionLog, string connectionString);
}
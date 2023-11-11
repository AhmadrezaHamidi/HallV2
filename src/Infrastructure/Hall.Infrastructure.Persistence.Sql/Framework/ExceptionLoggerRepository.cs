using Dapper;
using Microsoft.Data.SqlClient;
using Framework.Domain;

namespace Framework.EntityFrameworkCore;
public class ExceptionLoggerRepository : IExceptionLoggerRepository
{
    public async Task Save(ExceptionLogModel exceptionLog, string connectionString)
    {
        await using SqlConnection connection = new SqlConnection(connectionString);
        await connection.OpenAsync();
        var query = $"Insert into ExceptionLogs values(N'{exceptionLog.ApplicationName}"+"',N'"+exceptionLog.DateTime+"',N'"+exceptionLog.ExceptionMessage+"',N'"+exceptionLog.Stacktrace+"');";
        var num = await connection.ExecuteAsync(query);
        await connection.CloseAsync();
        query = (string) null;
    }
}
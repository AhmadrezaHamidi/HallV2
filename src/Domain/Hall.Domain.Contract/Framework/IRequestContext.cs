namespace Framework.Domain;

public interface IRequestContext
{
    Guid GetCommandId();

    void ClearContext();

    void SetCommandId(Guid commandId);
}
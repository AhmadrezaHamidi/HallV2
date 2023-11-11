using Framework.Domain;

namespace Framework.EntityFrameworkCore;


public class RequestContext:IRequestContext
{
    private Guid _commandId;

    public Guid GetCommandId() => this._commandId;

    public void ClearContext() => this._commandId = Guid.Empty;

    public void SetCommandId(Guid commandId) => this._commandId = commandId;
}
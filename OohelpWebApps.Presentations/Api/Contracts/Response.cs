using OohelpWebApps.Presentations.Api.Contracts.Common.Enums;

namespace OohelpWebApps.Presentations.Api.Contracts;

public abstract class Response
{
    public Status Status { get; set; }


    public static Response Ok => _ok;
    private static readonly Response _ok = new InternalResponse { Status = Status.Ok };

    public static Response InvalidRequest => _invalidRequest;
    private static readonly Response _invalidRequest = new InternalResponse { Status = Status.InvalidRequest };


    private class InternalResponse : Response
    {
    }

}

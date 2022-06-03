using OohelpWebApps.Presentations.Api.Contracts.Common.Enums;

namespace OohelpWebApps.Presentations.Api.Contracts;

public class BaseResponse : Common.Interfaces.IResponse
{
    public Status Status { get; set; }
    public string ErrorMessage { get; set; }
}

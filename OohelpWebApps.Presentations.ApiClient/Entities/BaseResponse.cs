using OohelpWebApps.Presentations.ApiClient.Entities.Common.Enums;
using OohelpWebApps.Presentations.ApiClient.Entities.Interfaces;

namespace OohelpWebApps.Presentations.ApiClient.Entities;
public class BaseResponse : IResponse
{
    public Status? Status { get; set; }
    public string ErrorMessage { get; set; }
}

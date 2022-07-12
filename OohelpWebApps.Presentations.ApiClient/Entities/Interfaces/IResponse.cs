using OohelpWebApps.Presentations.ApiClient.Entities.Common.Enums;

namespace OohelpWebApps.Presentations.ApiClient.Entities.Interfaces;
public interface IResponse
{
    Status? Status { get; set; }
    string ErrorMessage { get; set; }
}

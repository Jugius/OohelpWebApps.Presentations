using OohelpWebApps.Presentations.Api.Contracts.Common.Enums;

namespace OohelpWebApps.Presentations.Api.Contracts.Responses;
public class ErrorResponse : Response
{
    public ErrorResponse() { }
    public ErrorResponse(Status status)
    {
        this.Status = status;
    }
    public ErrorResponse(Status status, string error)
    {
        this.Status = status;
        ErrorMessage = string.IsNullOrEmpty(error) ? null : error;
    }
    public string ErrorMessage { get; set; }
}

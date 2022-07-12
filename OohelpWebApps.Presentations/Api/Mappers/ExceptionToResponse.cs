using OohelpWebApps.Presentations.Api.Contracts.Responses;
using OohelpWebApps.Presentations.Api.Exceptions;

namespace OohelpWebApps.Presentations.Api.Mappers;
public static class ExceptionToResponse
{
    public static ErrorResponse ToResponse(this Exception exception)
    {
        Contracts.Common.Enums.Status status = exception switch
        {
            ApiException a => a.Status,
            _ => Contracts.Common.Enums.Status.UnknownError
        };
        return new ErrorResponse(status, exception.Message);
    }
}

namespace OohelpWebApps.Presentations.ApiClient.Entities.Common.Enums;

public enum Status
{
    Ok,

    RequestDenied,
    InvalidKey,

    InvalidRequest,

    NotFound,
    DatabaseError,    

    UnknownError,

    HttpError,
    ReadResponseError
}

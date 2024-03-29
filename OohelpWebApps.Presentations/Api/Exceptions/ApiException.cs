﻿using OohelpWebApps.Presentations.Api.Contracts.Common.Enums;

namespace OohelpWebApps.Presentations.Api.Exceptions;

public class ApiException : Exception
{
    public Status Status { get; }

    public ApiException(Status status) : base(string.Empty)
    {
        this.Status = status;
    }
    public ApiException(Status status, string message) : base(message)
    {
        this.Status = status;
    }
}

using OohelpWebApps.Presentations.Api.Contracts.Common.Enums;

namespace OohelpWebApps.Presentations.Api.Exceptions
{
    public class ApiException : Exception
    {
        public Status Status { get; }

        public ApiException(Status st, string message) : base(message) { this.Status = st; }
        public ApiException(Status st) { this.Status = st; }
    }
}

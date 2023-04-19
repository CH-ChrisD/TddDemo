namespace TddDemo.Web.Endpoints
{
    internal enum Statuses
    {
        Successful,
        NotFound,
        Unsuccessful
    }

    internal class Response
    {
        internal Statuses Status { get; init; }
    }
}
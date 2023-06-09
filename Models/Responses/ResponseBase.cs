using System.Net;

namespace Backend.Models.Responses
{
    public abstract class ResponseBase
    {
        public HttpStatusCode StatusCode { get; set; }

        public string Message { get; set; }
    }
}

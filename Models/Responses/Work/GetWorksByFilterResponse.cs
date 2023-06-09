using Backend.Models.Entities;

namespace Backend.Models.Responses
{
    public class GetWorksByFilterResponse : ResponseBase
    {
        public Work[] Works { get; set; }
    }
}

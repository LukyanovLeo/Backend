using Backend.Models.Entities;

namespace Backend.Models.Responses
{
    public class GetWorksAllResponse : ResponseBase
    {
        public Work[] Works { get; set; }
    }
}

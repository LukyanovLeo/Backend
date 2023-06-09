using Backend.Models.Entities;

namespace Backend.Models.Responses
{
    public class GetWorkDetailsResponse : ResponseBase
    {
        public Work Work { get; set; }
    }
}

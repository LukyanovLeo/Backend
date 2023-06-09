using Backend.Models.Entities;

namespace Backend.Models.Responses
{
    public class GetCommentsAllResponse : ResponseBase
    {
        public Comment[] Comments { get; set; }
    }
}

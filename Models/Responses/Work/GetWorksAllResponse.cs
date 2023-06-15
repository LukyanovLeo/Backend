using Backend.Models.Entities;

namespace Backend.Models.Responses
{
    public class GetWorksAllResponse : ResponseBase
    {
        public List<Work> Works { get; set; } = new List<Work>();

        public List<byte[]> WorksData { get; set; } = new List<byte[]>();
    }
}

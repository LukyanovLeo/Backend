using Backend.Db;
using Backend.Models.Requests;
using Backend.Models.Responses;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers
{
    [ApiController]
    [Route("work")]
    public class WorkController : ControllerBase
    {
        private readonly DbHelper _dbHelper;


        public WorkController(DbHelper dbHelper)
        {
            _dbHelper = dbHelper;
        }

        [HttpGet]
        [Route("all")]
        public IActionResult GetWorksAll()
        {
            return null;   
        }

        [HttpPost]
        [Route("filter")]
        public IActionResult GetWorksByFilter()
        {
            return null;
        }

        [HttpPost]
        [Route("details")]
        public IActionResult GetWorkDetails()
        {
            return null;
        }

        [HttpPost]
        [Route("add")]
        public IActionResult AddWork()
        {
            return null;
        }

        [HttpPost]
        [Route("edit")]
        public IActionResult EditWork()
        {
            return null;
        }

        [HttpPost]
        [Route("remove")]
        public IActionResult RemoveWork()
        {
            var a = new HashSet<int>();
            return null;
        }

        [HttpPost]
        [Route("{id:int}/comment/add")]
        public async Task<AddCommentResponse> AddComment(AddCommentRequest request)
        {
            var response = await _dbHelper.AddComment(request);

            return response;
        }

        [HttpPost]
        [Route("{id:int}/comment/edit")]
        public async Task<EditCommentResponse> EditComment(EditCommentRequest request)
        {
            var response = await _dbHelper.EditComment(request);

            return response;
        }

        [HttpPost]
        [Route("{id:int}/comment/remove")]
        public async Task<RemoveCommentResponse> RemoveComment(RemoveCommentRequest request)
        {
            var response = await _dbHelper.RemoveComment(request);

            return response;
        }

        [HttpPost]
        [Route("{id:int}/comment/all")]
        public async Task<IEnumerable<GetCommentsAllResponse>> GetCommentsAll(GetCommentsAllRequest request)
        {
            var response = await _dbHelper.GetCommentsAll(request);

            return response;
        }
    }
}
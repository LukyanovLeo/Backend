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


        public WorkController(IDbHelper dbHelper)
        {
            _dbHelper = (DbHelper)dbHelper;
        }

        [HttpGet]
        [Route("all")]
        public async Task<GetWorksAllResponse> GetWorksAll(GetWorksAllRequest request)
        {
            var response = await _dbHelper.GetWorksAll(request);
            return response;
        }

        [HttpPost]
        [Route("filter")]
        public async Task<GetWorksByFilterResponse> GetWorksByFilter(GetWorksByFilterRequest request)
        {
            var response = await _dbHelper.GetWorksByFilter(request);
            return response;
        }

        [HttpPost]
        [Route("{workId:int}/details")]
        public async Task<GetWorkDetailsResponse> GetWorkDetails(GetWorkDetailsRequest request)
        {
            var response = await _dbHelper.GetWorkDetails(request);
            return response;
        }

        [HttpPost, DisableRequestSizeLimit]
        [Route("add")]
        public async Task<AddWorkResponse> AddWork(AddWorkRequest request)
        {
            var work = Request.Form.Files[0];
            var uploadFolder = Path.Combine(Directory.GetCurrentDirectory(), "UploadedFiles");

            var response = await _dbHelper.AddWork(request);
            return response;
        }

        [HttpPost]
        [Route("{workId:int}/edit")]
        public async Task<EditWorkResponse> EditWork(EditWorkRequest request)
        {
            var response = await _dbHelper.EditWork(request);
            return response;
        }

        [HttpPost]
        [Route("{workId:int}/remove")]
        public async Task<RemoveWorkResponse> RemoveWork(RemoveWorkRequest request)
        {
            var response = await _dbHelper.RemoveWork(request);
            return response;
        }

        [HttpPost]
        [Route("{workId:int}/comment/add")]
        public async Task<AddCommentResponse> AddComment(AddCommentRequest request)
        {
            var response = await _dbHelper.AddComment(request);
            return response;
        }

        [HttpPost]
        [Route("{workId:int}/comment/{commentId}/edit")]
        public async Task<EditCommentResponse> EditComment(EditCommentRequest request)
        {
            var response = await _dbHelper.EditComment(request);
            return response;
        }

        [HttpPost]
        [Route("{workId:int}/comment/{commentId:int}/remove")]
        public async Task<RemoveCommentResponse> RemoveComment(RemoveCommentRequest request)
        {
            var response = await _dbHelper.RemoveComment(request);
            return response;
        }

        [HttpPost]
        [Route("{workId:int}/comment/all")]
        public async Task<GetCommentsAllResponse> GetCommentsAll(GetCommentsAllRequest request)
        {
            var response = await _dbHelper.GetCommentsAll(request);
            return response;
        }
    }
}
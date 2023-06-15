using Backend.Db;
using Backend.Models.Requests;
using Backend.Models.Responses;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Net;
using System.Text;

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
        public async Task<GetWorksAllResponse> GetWorksAll()
        {
            var worksMetadata = await _dbHelper.GetWorksAll();

            var response = new GetWorksAllResponse();
            foreach (var filePath in Directory.GetFiles(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "pictures")))
            {
                var fileInfo = new FileInfo(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "pictures"));
                var buffer = new byte[fileInfo.Length];

                using (var ms = new MemoryStream())
                {
                    int read;
                    while ((read = ms.Read(buffer, 0, buffer.Length)) > 0)
                    {
                        ms.Write(buffer, 0, read);
                    }

                    response.WorksData.Add(ms.ToArray());
                }

                fileInfo.Delete();
            }

            return response;

            //var picturesPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "pictures");




            //foreach (var file in Directory.GetFiles(picturesPath))
            //{
            //    using (var content = new FileStream(Path.Combine(picturesPath, file), FileMode.Open, FileAccess.Read, FileShare.Read))
            //    {
            //        var buffer = new byte[content.Length];
            //        await content.ReadAsync(buffer, 0, buffer.Length);

            //        yield return new GetWorksAllResponse
            //        {

            //        };
            //    }
            //}




            //return response;


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

        [HttpPost]
        [Route("add")]
        public async Task<AddWorkResponse> AddWork([FromForm] AddWorkRequest request)
        {
            if (request.Picture.Length > 0)
            {
                var response = await _dbHelper.AddWork(request);
                return response;
            }
            else
            {
                return new AddWorkResponse
                {
                    StatusCode = HttpStatusCode.BadRequest,
                    Message = "Error",
                };
            }
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
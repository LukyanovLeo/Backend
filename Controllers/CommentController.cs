using Backend.Db;
using Backend.Models.Requests.Comment;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers
{
    public class CommentController : Controller
    {
        private readonly DbHelper _dbHelper;


        public CommentController(DbHelper dbHelper)
        {
            _dbHelper = dbHelper;
        }

        public IActionResult AddComment(AddCommentRequest request)
        {
            _dbHelper.Login(request);

            return Ok();
        }

        public IActionResult EditComment(EditCommentRequest request)
        {
            _dbHelper.Login(request);

            return Ok();
        }

        public IActionResult RemoveComment(RemoveCommentRequest request)
        {
            _dbHelper.Login(request);

            return Ok();
        }
    }
}

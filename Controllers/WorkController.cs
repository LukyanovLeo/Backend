using Backend.Db;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WorkController : ControllerBase
    {
        private readonly DbHelper _dbHelper;


        public WorkController(DbHelper dbHelper)
        {
            _dbHelper = dbHelper;
        }

        public IActionResult GetWorksAll()
        {
            return null;   
        }

        public IActionResult GetWorksByFilter()
        {
            return null;
        }

        public IActionResult GetWorkInfo()
        {
            return null;
        }

        public IActionResult GetWorkDetails()
        {
            return null;
        }

        public IActionResult AddWork()
        {
            return null;
        }

        public IActionResult EditWork()
        {
            return null;
        }

        public IActionResult RemoveWork()
        {
            var a = new HashSet<int>();
            return null;
        }
    }
}
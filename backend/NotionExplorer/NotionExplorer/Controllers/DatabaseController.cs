using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace NotionExplorer.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DatabaseController : Controller
    {
        private readonly ILogger<DatabaseController> _loger;

        public DatabaseController(
            ILogger<DatabaseController> loger)
        {
            _loger = loger;
        }

        [HttpGet]
        public IActionResult Get(string databaseId)
        {
        }
    }
}
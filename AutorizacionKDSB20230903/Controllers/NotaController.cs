using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AutorizacionKDSB20230903.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotaController : ControllerBase
    {
        static List<object> data = new List<object>();

        [HttpGet]
        [AllowAnonymous]
        public IEnumerable<object> Get()
        {
            return data;
        }

        [Authorize]
        [HttpPost]
        public IActionResult Post(string name, string Note)
        {
            data.Add(new { name, Note });
            return Ok();
        }
    }
}

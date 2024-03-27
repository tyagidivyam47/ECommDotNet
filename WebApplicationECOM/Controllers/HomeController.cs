using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Xml;
using WebApplicationECOM.Models;

namespace WebApplicationECOM.Controllers
{
    [ApiVersion("1.0")]
    [Route("api/Home")]  // Using Query Params and Media Type
    //[Route("api/v{version:apiVersion}/Home")]  // Using URL Path
    [ApiController]
    public class HomeController : ControllerBase
    {
        static List<BookWriter> Writers = new List<BookWriter>()
        {
            new BookWriter(){Id=1, Name="Tarun"},
            new BookWriter(){Id=2, Name="Varun"}
        };

        [HttpGet]
        public IEnumerable<BookWriter> Get() {
            return Writers;
        }
    }
}

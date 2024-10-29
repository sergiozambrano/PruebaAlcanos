using Microsoft.AspNetCore.Mvc;

namespace Alcanos.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TratamientoController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

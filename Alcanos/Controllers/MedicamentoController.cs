using Microsoft.AspNetCore.Mvc;

namespace Alcanos.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MedicamentoController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

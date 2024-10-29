using Microsoft.AspNetCore.Mvc;
using Modelos.DTO;

namespace Alcanos.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EnfermedadController : Controller
    {
        [HttpGet]
        public IActionResult Obtener() 
        { 
            
        }

        [HttpPost()]
        public IActionResult Crear(EnfermedadDTO)
        {

        }

        [HttpPut()]
        public IActionResult Actualizar(EnfermedadDTO)
        {

        }

        //public IActionResult Index()
        //{
        //    return View();
        //}
    }
}

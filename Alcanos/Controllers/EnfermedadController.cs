using Infracestructura.Conexion;
using Microsoft.AspNetCore.Mvc;
using Modelos.DTO;
using System.Data;
using System.Data.SqlClient;

namespace Alcanos.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EnfermedadController(Conexion conexion) : Controller
    {
        private readonly Conexion _conexion = conexion;

        [HttpGet]
        [Route("/Enf6Med")]
        public IActionResult ObtenerEnfermedad6Medicamentos()
        {
            DataTable dataTable = _conexion.EjecutarSP("SelectEnfermedades6");

            return Ok(dataTable);
        }

        [HttpGet]
        [Route("/EnfMedTra")]
        public IActionResult ObtenerEnfMediYTrat()
        {
            DataTable dataTable = _conexion.EjecutarSP("SelectEnfermedad7_12");

            return Ok(dataTable);
        }

        [HttpGet]
        [Route("/CantTrayMedi")]
        public IActionResult ObtenerCantidadTraMedXEnfermedad()
        {
            DataTable dataTable = _conexion.EjecutarSP("SelectCantTrayMedi");

            return Ok(dataTable);
        }

        [HttpPost()]
        public IActionResult Crear(EnfermedadDTO enfermedadDTO)
        {
            SqlParameter parametros = new SqlParameter("Nombre", enfermedadDTO.NombreEnfermedad);

            DataTable dataTable = _conexion.EjecutarSP("InsertEnfermedad", parametros);

            return Ok(dataTable);
        }

        //[HttpPut()]
        //public IActionResult Actualizar(EnfermedadDTO)
        //{

        //}
    }
}

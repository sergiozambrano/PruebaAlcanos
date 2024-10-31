using Infracestructura.Conexion;
using Microsoft.AspNetCore.Mvc;
using Modelos.DTO;
using System.Data.SqlClient;
using System.Data;

namespace Alcanos.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MedicamentoController(Conexion conexion) : Controller
    {
        private readonly Conexion _conexion = conexion;

        [HttpGet]
        public IActionResult ObtenerMedicamento2Tratamietno()
        {
            DataTable dataTable = _conexion.EjecutarSP("SelectMedicamento2");

            return Ok(dataTable);
        }

        [HttpPost()]
        public IActionResult Crear(MedicamentoDTO medicamentoDTO)
        {
            SqlParameter parametros = new SqlParameter("Nombre", medicamentoDTO.NombreMedicamento);

            DataTable dataTable = _conexion.EjecutarSP("InsertMedicamento", parametros);

            return Ok(dataTable);
        }
    }
}

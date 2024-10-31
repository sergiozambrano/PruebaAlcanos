using Infracestructura.Conexion;
using Microsoft.AspNetCore.Mvc;
using Modelos.DTO;
using System.Data.SqlClient;
using System.Data;

namespace Alcanos.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TratamientoController(Conexion conexion) : Controller
    {
        private readonly Conexion _conexion = conexion;

        [HttpPost()]
        public IActionResult Crear(MedicamentoDTO medicamentoDTO)
        {
            SqlParameter parametros = new SqlParameter("Nombre", medicamentoDTO.NombreMedicamento);

            DataTable dataTable = _conexion.EjecutarSP("InsertTratamiento", parametros);

            return Ok(dataTable);
        }
    }
}

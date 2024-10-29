using System.Data.Common;
using System.Data;
using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace Infracestructura.Conexion
{
    public class Conexion
    {
        private readonly string? _cadenaConxion;
        private SqlConnection _conexion;

        private static readonly object _lock = new object();
        private static Conexion _instacia;

        public Conexion(IConfiguration configuracion)
        {
            _cadenaConxion = configuracion.GetConnectionString("Conexion");

            _conexion = new SqlConnection(_cadenaConxion);
        }

        public static Conexion GetInstancia(IConfiguration configuracion)
        {
            if (_instacia == null)
            {
                lock (_lock)
                {
                    _instacia ??= new Conexion(configuracion);
                }
            }

            return _instacia;
        }

        public void AbrirConexion()
        {
            if (_conexion.State == ConnectionState.Closed)
                _conexion.Open();
        }

        public void CerrarConexion()
        {
            if (_conexion.State == ConnectionState.Open)
            {
                _conexion.Close();
            }
        }

        public DataTable EjecutarSP(string procedimiento)
        {
            AbrirConexion();
            using var command = new SqlCommand(procedimiento, _conexion);
            using var adapter = new SqlDataAdapter(command);
            var dataTable = new DataTable();
            adapter.Fill(dataTable);
            return dataTable;
        }

        public void Dispose()
        {
            CerrarConexion();
            _conexion?.Dispose();
        }
    }
}

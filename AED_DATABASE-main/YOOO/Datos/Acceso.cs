using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Datos
{
    public class Acceso
    {
        private string Cadena = "Data Source=(local); Initial Catalog=Datos;Integrated Security=True";
        public SqlConnection Conexion;

        public Acceso()
        {
            Conectar();
        }

        private void Conectar()
        {
            Conexion = new SqlConnection(Cadena);
        }
    }
}

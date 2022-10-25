using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Datos;
using System.Data;

namespace Negocio
{
    public class Crud
    {
        private SqlCommand Comando;
        Datos.Acceso Cnn = new Datos.Acceso();

        public bool Insertar(string Tabla, int C, string N, string A, DateTime F, int Nota)
        {
            Cnn.Conexion.Open();
            Comando = new SqlCommand();
            Comando.CommandText = "insert into " + Tabla + " (Carnet, Nombres, Apellidos, FechaNac, Nota) " +
                " values(" + C + ", '" + N + "', '" + A + "', '" + string.Format("{0: yyyy-MM-dd}", F) + "', " + Nota + ")";

            Comando.Connection = Cnn.Conexion;
            int i = Comando.ExecuteNonQuery();
            Cnn.Conexion.Close();

            if (i > 0)
                return true;
            else
                return false;

        }

        // Metodo para eliminar
        public bool Eliminar(string Tabla, int C)
        {
            Cnn.Conexion.Open();
            Comando = new SqlCommand();
            Comando.CommandText = "delete from " + Tabla + " where Carnet=" + C;

            Comando.Connection = Cnn.Conexion;
            int i = Comando.ExecuteNonQuery();
            Cnn.Conexion.Close();

            if (i > 0)
                return true;
            else
                return false;

        }

        // Metodos para modificar
        public bool Modificar(string Tabla, int C, string N, string A, DateTime F, int Nota)
        {
            Cnn.Conexion.Open();
            Comando = new SqlCommand();
            Comando.CommandText = "update " + Tabla + " set Nombres='" + N + "', Apellidos='" + A + "', FechaNac='" + string.Format("{0: yyyy-MM-dd}", F)
                + "', Nota=" + Nota + " where Carnet=" + C;

            Comando.Connection = Cnn.Conexion;
            int i = Comando.ExecuteNonQuery();
            Cnn.Conexion.Close();

            if (i > 0)
                return true;
            else
                return false;
        }

        // Metodo para consultar datos de un estudiante
        public DataTable Consultar(string Tabla, int C)
        {
            DataSet ds = new DataSet();
            SqlDataAdapter da;
            DataTable dt = new DataTable();

            string sql = "select * from " + Tabla + " where Carnet=" + C;

            da = new SqlDataAdapter(sql, Cnn.Conexion);
            da.Fill(ds, Tabla);
            dt = ds.Tables[Tabla];
            return (dt);
        }

        //Conusltar todos los registros
        public DataTable Consultar(string Tabla)
        {
            DataSet ds = new DataSet();
            SqlDataAdapter da;
            DataTable dt = new DataTable();

            string sql = "select * from " + Tabla;

            da = new SqlDataAdapter(sql, Cnn.Conexion);
            da.Fill(ds, Tabla);
            dt = ds.Tables[Tabla];
            return (dt);
        }

    }
}

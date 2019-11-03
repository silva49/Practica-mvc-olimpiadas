using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
namespace MODELO
{
    public class ClsDatos
    {

        #region Declaración de variables
        SqlConnection cnnConexion = null;
        SqlCommand cmdComando = null;
        SqlDataAdapter daAdaptador = null;
        DataTable Dtt = null;
        String strCadenaConexion = string.Empty;
        #endregion

        #region Cadena de conexión
        public ClsDatos()
        {
            this.strCadenaConexion = @"Data Source=SALA403-6\SQLEXPRESS;Initial Catalog=bdolimpiadas;Integrated Security=True";
        }
        #endregion

        public DataTable RetornaTabla(SqlParameter[] parParametros, string parTSQL)
        {
            Dtt = null;
            try
            {
                Dtt = new DataTable();
                cnnConexion = new SqlConnection(strCadenaConexion);
                cmdComando = new SqlCommand();
                cmdComando.Connection = cnnConexion;
                cmdComando.CommandType = CommandType.StoredProcedure;
                cmdComando.CommandText = parTSQL;

                if (parParametros != null)
                { cmdComando.Parameters.AddRange(parParametros); }




                daAdaptador = new SqlDataAdapter(cmdComando);
                daAdaptador.Fill(Dtt);
            }



            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            finally
            {
                cnnConexion.Dispose();
                cmdComando.Dispose();
                daAdaptador.Dispose();
            }

            return Dtt;

        }

      public void EjecutarSP(SqlParameter[] parametros, string spNombre) {
            try
            {
                cnnConexion = new SqlConnection(strCadenaConexion);
                cmdComando = new SqlCommand();
                cmdComando.Connection = cnnConexion;
                cnnConexion.Open();
                cmdComando.CommandType = CommandType.StoredProcedure;
                cmdComando.CommandText = spNombre;
                cmdComando.Parameters.AddRange(parametros);
                cmdComando.ExecuteNonQuery();
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message);
            }
            finally
            {
                cnnConexion.Dispose();
                cmdComando.Dispose();
              
            }

        }
    }

}


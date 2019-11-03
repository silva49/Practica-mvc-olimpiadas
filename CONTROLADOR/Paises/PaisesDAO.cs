using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using MODELO;
namespace CONTROLADOR.Paises
{
    public class PaisesDAO
    {
        ClsDatos clsDatos = null;
        PaisesDTO paisesDTO = null;
        DataTable listarDatos = null;

       public PaisesDAO(PaisesDTO paisesDTO)
        {
            this.paisesDTO = paisesDTO;
        }
        public DataTable ListarPaises()
        {
            listarDatos = new DataTable(); 
            try
            {
                clsDatos = new ClsDatos();
                SqlParameter[] parametros = null;

                if (this.paisesDTO == null)
                {



                    parametros = new SqlParameter[2];

                    parametros[0] = new SqlParameter();
                    parametros[0].ParameterName = "@idpais";
                    parametros[0].SqlDbType = SqlDbType.Int;
                    parametros[0].SqlValue = paisesDTO.getIdpais();

                    parametros[1] = new SqlParameter();
                    parametros[1].ParameterName = "@nombrepais";
                    parametros[1].SqlDbType = SqlDbType.VarChar;
                    parametros[1].Size = 50;
                    parametros[1].SqlValue = paisesDTO.getNombrepais();
                }
                else
                {
                    parametros = null;
                }
               

                listarDatos = clsDatos.RetornaTabla(parametros,"spConsultaPaises");

            }
            catch(Exception exception)
            {
                throw new Exception(exception.Message);

            }
            return listarDatos;   

        }


        public void GuardarPais()
        {

            try{
                clsDatos = new ClsDatos();
                SqlParameter[] parametro = new SqlParameter[1];

                parametro[0] = new SqlParameter();
                parametro[0].ParameterName = "@nombrepais";
                parametro[0].SqlDbType = SqlDbType.VarChar;
                parametro[0].Size = 50;
                parametro[0].SqlValue = paisesDTO.getNombrepais();

                clsDatos.EjecutarSP(parametro,"spNuevoPais" );
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message);
            }
        }
        public void GuardarCambios()
        {

            try
            {
                clsDatos = new ClsDatos();
                SqlParameter[] parametro = new SqlParameter[2];

                parametro[0] = new SqlParameter();
                parametro[0].ParameterName = "@idpais";
                parametro[0].SqlDbType = SqlDbType.Int;
                parametro[0].SqlValue = paisesDTO.getIdpais();


                parametro[1] = new SqlParameter();
                parametro[1].ParameterName = "@nombrepais";
                parametro[1].SqlDbType = SqlDbType.VarChar;
                parametro[1].Size = 50;
                parametro[1].SqlValue = paisesDTO.getNombrepais();

                clsDatos.EjecutarSP(parametro, "spGuardarCambiosPais");
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message);
            }
        }


        public void EliminarPais()
        {

            try
            {
                clsDatos = new ClsDatos();
                SqlParameter[] parametro = new SqlParameter[1];

                parametro[0] = new SqlParameter();
                parametro[0].ParameterName = "@idpais";
                parametro[0].SqlDbType = SqlDbType.Int;
                
                parametro[0].SqlValue = paisesDTO.getIdpais();

                clsDatos.EjecutarSP(parametro, "spEliminarPais");
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message);
            }
        }

    }
}

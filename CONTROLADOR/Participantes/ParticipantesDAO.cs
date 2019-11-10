using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using MODELO;
namespace CONTROLADOR.Participantes
{
    public class ParticipantesDAO
    {
        ClsDatos clsDatos = null;
        ParticipantesDTO participantesDTO = null;
        DataTable listaDatos = null;


        public ParticipantesDAO(ParticipantesDTO participantesDTO)
        {
            this.participantesDTO = participantesDTO;
        }

        public void GuardarParticipante()
        {

            try
            {
                clsDatos = new ClsDatos();
                SqlParameter[] parametro = new SqlParameter[4];

                parametro[0] = new SqlParameter();
                parametro[0].ParameterName = "@cedula";
                parametro[0].SqlDbType = SqlDbType.Int;
                parametro[0].SqlValue = participantesDTO.getCedula();

                parametro[1] = new SqlParameter();
                parametro[1].ParameterName = "@nombre";
                parametro[1].SqlDbType = SqlDbType.VarChar;
                parametro[1].Size = 100;
                parametro[1].SqlValue = participantesDTO.getNombre();

                parametro[2] = new SqlParameter();
                parametro[2].ParameterName = "@pais";
                parametro[2].SqlDbType = SqlDbType.Int;
                parametro[2].SqlValue = participantesDTO.getPais();

                parametro[3] = new SqlParameter();
                parametro[3].ParameterName = "@edad";
                parametro[3].SqlDbType = SqlDbType.TinyInt;
                parametro[3].SqlValue = participantesDTO.getEdad();



                clsDatos.EjecutarSP(parametro, "spGuardarNuevoParticipantes");
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message);
            }
        }

        public DataTable ListarParticipantes()
        {
            listaDatos = new DataTable();
            try
            {
                clsDatos = new ClsDatos();
                SqlParameter[] parametros = null;
                listaDatos = clsDatos.RetornaTabla(parametros, "spConsultaParticipantes");


            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message);
            }
            return listaDatos;
        }

        public void GuardarCambiosParticipanteSinPais()
        {

            try
            {
                clsDatos = new ClsDatos();
                SqlParameter[] parametro = new SqlParameter[3];

                parametro[0] = new SqlParameter();
                parametro[0].ParameterName = "@cedula";
                parametro[0].SqlDbType = SqlDbType.Int;
                parametro[0].SqlValue = participantesDTO.getCedula();

                parametro[1] = new SqlParameter();
                parametro[1].ParameterName = "@nombre";
                parametro[1].SqlDbType = SqlDbType.VarChar;
                parametro[1].Size = 100;
                parametro[1].SqlValue = participantesDTO.getNombre();

                parametro[2] = new SqlParameter();
                parametro[2].ParameterName = "@edad";
                parametro[2].SqlDbType = SqlDbType.TinyInt;
                parametro[2].SqlValue = participantesDTO.getEdad();



                clsDatos.EjecutarSP(parametro, "spGuardarCambiosParticipanteSINPais");
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message);
            }
        }


        public void GuardarCambiosParticipanteConPais()
        {

            try
            {
                clsDatos = new ClsDatos();
                SqlParameter[] parametro = new SqlParameter[4];

                parametro[0] = new SqlParameter();
                parametro[0].ParameterName = "@cedula";
                parametro[0].SqlDbType = SqlDbType.Int;
                parametro[0].SqlValue = participantesDTO.getCedula();

                parametro[1] = new SqlParameter();
                parametro[1].ParameterName = "@nombre";
                parametro[1].SqlDbType = SqlDbType.VarChar;
                parametro[1].Size = 100;
                parametro[1].SqlValue = participantesDTO.getNombre();


                parametro[2] = new SqlParameter();
                parametro[2].ParameterName = "@pais";
                parametro[2].SqlDbType = SqlDbType.Int;
                parametro[2].SqlValue = participantesDTO.getPais();

                parametro[3] = new SqlParameter();
                parametro[3].ParameterName = "@edad";
                parametro[3].SqlDbType = SqlDbType.TinyInt;
                parametro[3].SqlValue = participantesDTO.getEdad();



                clsDatos.EjecutarSP(parametro, "spGuardarCambiosParticipanteCONPais");
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message);
            }
        }


        public void EliminarParticipantes()
        {

            try
            {
                clsDatos = new ClsDatos();
                SqlParameter[] parametro = new SqlParameter[1];

                parametro[0] = new SqlParameter();
                parametro[0].ParameterName = "@cedula";
                parametro[0].SqlDbType = SqlDbType.Int;
                parametro[0].SqlValue = participantesDTO.getCedula();



                clsDatos.EjecutarSP(parametro, "spEliminarParticipantes");
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message);
            }
        }

    }
}
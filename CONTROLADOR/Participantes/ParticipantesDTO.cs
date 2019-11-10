using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CONTROLADOR.Participantes
{
  public  class ParticipantesDTO
    {
        private int cedula;
        private string nombre;
        private int pais;
        private int edad;

        public void setCedula(int valor)

        {
            this.cedula = valor;
        }

          public int getCedula()
        {
            return this.cedula;
        }

        public void setNombre(string valor)
        {
            this.nombre = valor;
        }

      public string getNombre()
        {
            return this.nombre;
        }

        public void setPais(int valor)

        {
            this.pais= valor;
        }

        public int getPais()
        {
            return this.pais;
        }

        public void setEdad(int valor)

        {
            this.edad= valor;
        }

        public int getEdad()
        {
            return this.edad;
        }


    }
}

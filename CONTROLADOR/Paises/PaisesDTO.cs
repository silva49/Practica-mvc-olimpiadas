using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CONTROLADOR.Paises
{
   public class PaisesDTO
    {
        private int idpais;
        private string nombrepais;

        public void setIdpais(int valor )
        {
            this.idpais = valor;
        }
        public int getIdpais()
        {
            return this.idpais;
        }

        public void setNombrepais(string valor)
        {
            this.nombrepais = valor;
        }
        public string getNombrepais()
        {
            return this.nombrepais;
        }
    }
}

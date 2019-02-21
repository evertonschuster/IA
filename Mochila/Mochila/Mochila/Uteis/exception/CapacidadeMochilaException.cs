using System;
using System.Collections.Generic;
using System.Text;

namespace AlgoritmoMochila.Uteis.exception
{
    internal  class CapacidadeMochilaException : Exception 
    {
        public CapacidadeMochilaException(bool isCheio, int capacidadeLivre)
        {
            IsCheio = isCheio;
            CapacidadeLivre = capacidadeLivre;
        }

        public Boolean  IsCheio{ get;  }
        public int  CapacidadeLivre{ get; }
    }
}

using CarteiroFormiga.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarteiroFormiga.Uteis.Exceptions
{
    class RotaRepetidaException : Exception
    {

        public Rota Rota { get; private set; }
        public RotaRepetidaException(Rota rota)
        {
            this.Rota = rota.Clone();
        }
    }
}

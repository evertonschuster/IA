using CarteiroFormiga.Uteis;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarteiroFormiga.Entidades
{
    class Rota
    {
        public Rota(Cidade cidade, int distancia)
        {
            this.Distancia = distancia;
            this.Cidade = cidade;
        }

        public Cidade Cidade { get; set; }
        public int Distancia { get; set; }

        internal Rota Clone()
        {
            return this.CloneTheObject();
        }
    }
}

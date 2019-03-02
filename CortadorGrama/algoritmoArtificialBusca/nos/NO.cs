using System;
using System.Collections.Generic;
using System.Text;

namespace algoritmoArtificialBusca.nos
{
    public class NO
    {

        public int valor{ get; set; }// Busca - Resultado

        public int custo { get; set; }

        public NO noPai { get; set; }
        public NO noEsquerda { get; set; }
        public NO noDireita { get; set; }

        public NO(int valor)
        {
            this.valor = valor;
            this.custo = 0;
        }

        public NO(int valor, int custo)
        {
            this.valor = valor;
            this.custo = custo;
        }

    }
}

using AlgoritmoMochila.Entidade;
using System;
using System.Collections.Generic;
using System.Text;

namespace AlgoritmoMochila.Genetica
{
    internal class Crossover
    {
        private Mochila MochilaPai { get;  }
        private Mochila MochilaMae { get;  }

        public Crossover(Mochila mochilaPai, Mochila mochilaMae)
        {
            MochilaPai = mochilaPai;
            MochilaMae = mochilaMae;
        }

        public List<Mochila> gerarFilhos()
        {
            List<Mochila> filhos = new List<Mochila>();
            return null;
        }

    }
}

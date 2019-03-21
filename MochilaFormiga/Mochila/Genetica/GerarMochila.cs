using AlgoritmoMochila.Entidade;
using AlgoritmoMochila.Uteis.exception;
using System;
using System.Collections.Generic;
using System.Text;

namespace AlgoritmoMochila
{
    internal class GerarMochila
    {
        private List<Objeto> Objetos { get; }
        private Mochila Mochila { get; set; }
        private Random r = new Random();


        public GerarMochila(List<Objeto> objetos, Mochila mochila)
        {
            Objetos = objetos;
            Mochila = mochila;
        }

        public Mochila GerarPopulacaoInicial()
        {
            Mochila novaMochila = this.Mochila.Clone();
            List<Objeto> objetoAdicionados = novaMochila.Objetos;
            //sorteia um objeto para adicionar na mochila

            while (!novaMochila.IsCheia)
            {

                //procura um objeto ainda nao adicionado
                Objeto novoObjeto = this.SortearObjeto();

                while (objetoAdicionados.Find(o => o.Id == novoObjeto.Id) != null)
                {
                    novoObjeto = this.SortearObjeto();
                }

                //gero o Objeto para adicionar na mochila
                novoObjeto = this.GerarItem(novoObjeto);
                try
                {
                    novaMochila.AdicionarItemMochila(novoObjeto);
                }catch(CapacidadeMochilaException ex)
                {
                    return this.GerarPopulacaoInicial();
                }


                if (objetoAdicionados.Count == this.Objetos.Count)
                {
                    break;
                }

            }
            if (novaMochila.Objetos.Count == this.Objetos.Count)
            {
                return novaMochila;
            }
            else
            {
                return this.GerarPopulacaoInicial();
            }
        }

        private Objeto SortearObjeto()
        {
            int index = r.Next(Objetos.Count);
            return Objetos[index];
        }

        private Objeto GerarItem(Objeto obj)
        {
            int probabilidade = r.Next(Convert.ToInt32(101) );
            int quantidade = 0;
            if (probabilidade >= 50)
            {
                quantidade = 1;
            }


            Objeto objeto = new Objeto(obj, quantidade);
            return objeto;
        }

    }
}

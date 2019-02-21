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
        private List<Objeto> objetoAdicionados;
        private Random r = new Random();


        public GerarMochila(List<Objeto> objetos, Mochila mochila)
        {
            Objetos = objetos;
            Mochila = mochila;
        }

        public Mochila GerarPopulacaoInicial()
        {
            Mochila novaMochila = this.Mochila.Clone();
            objetoAdicionados = new List<Objeto>();
            //sorteia um objeto para adicionar na mochila

            while (!novaMochila.IsCheia)
            {
                //procura um objeto ainda nao adicionado
                Objeto novoObjeto = this.SortearObjeto();

                var tste = objetoAdicionados.Find(o => o.Id == novoObjeto.Id);

                while (objetoAdicionados.Find(o => o.Id == novoObjeto.Id) != null)
                {
                    novoObjeto = this.SortearObjeto();
                }
                objetoAdicionados.Add(novoObjeto);

                try
                {
                    novoObjeto = this.GerarItem(novoObjeto);
                    novaMochila.AdicionarItemMochila(novoObjeto);
                }
                catch (CapacidadeMochilaException ex)
                {
                    novoObjeto = this.GerarItem(novoObjeto, ex.CapacidadeLivre);
                    novaMochila.AdicionarItemMochila(novoObjeto);

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

        private Objeto GerarItem(Objeto obj, int limite = -1)
        {
            int quantiadde;
            if (limite == 0)
            {
                quantiadde = 0;
            }
            else if (limite == -1)
            {
                if (this.objetoAdicionados.Count <= (this.Objetos.Count / 3)* 2)
                {
                    quantiadde = r.Next(1,obj.QuantidadeMaximaMochila / 2);
                }
                else
                {
                    quantiadde = r.Next(obj.QuantidadeMaximaMochila + 1);
                }
            }
            else
            {
                quantiadde = r.Next(limite);

            }


            obj = new Objeto(obj, quantiadde);

            return obj;
        }

    }
}

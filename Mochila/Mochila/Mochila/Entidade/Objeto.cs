using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace AlgoritmoMochila.Entidade
{
    internal class Objeto
    {


        public Objeto(long id, int beneficio, int peso)
        {
            this.Id = id;
            this.Beneficio = beneficio;
            this.Peso = peso;

            this.Coeficiente = beneficio / peso;
            this.Quantidade = 0;
        }

        public Objeto(Objeto obj, int quantiadde)
        {
            this.Id = obj.Id;
            this.Beneficio = obj.Beneficio;
            this.Peso = obj.Peso;
            this.Quantidade = quantiadde;

            this.Coeficiente = obj.Beneficio / obj.Peso;
        }

        public Objeto(long id, int beneficio, int peso, int quantidade)
        {
            this.Id = id;
            this.Beneficio = beneficio;
            this.Peso = peso;
            this.Quantidade = quantidade;

            this.Coeficiente = beneficio / peso;
        }

        public long Id { get; }
        public int Beneficio { get; }
        public int Peso { get; }
        public int Quantidade { get; }

        public int QuantidadeMaximaMochila { get; set; }
        public Double Coeficiente { get; set; }
        public double FuncaoObjetiva => this.Beneficio * this.Quantidade;



        internal Objeto CalcularQuantidadeMaximaMochila(Mochila mochila)
        {
            this.QuantidadeMaximaMochila = mochila.Capacidade / this.Peso;

            return this;
        }
    }
}

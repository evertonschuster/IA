using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace AlgoritmoMochila.Entidade
{
    internal class Objeto : IComparable
    {
        private const int QUANTIDADE_MAXIMA = 1;

        public Objeto(long id, int beneficio, int peso)
        {
            this.Quantidade = 0;
            this.Id = id;
            this.Beneficio = beneficio;
            this.Peso = peso;
        }

        public Objeto(Objeto obj, int quantidade)
        {
            if (quantidade > QUANTIDADE_MAXIMA)
            {
                throw new ArgumentException("Quantidade maxima atingida");
            }
            this.Quantidade = quantidade;
            this.Id = obj.Id;
            this.Beneficio = obj.Beneficio;
            this.Peso = obj.Peso;
        }

        public Objeto(long id, int beneficio, int peso, int quantidade)
        {
            if (quantidade > QUANTIDADE_MAXIMA)
            {
                throw new ArgumentException("Quantidade maxima atingida");
            }
            this.Quantidade = quantidade;
            this.Id = id;
            this.Beneficio = beneficio;
            this.Peso = peso;
        }

        public long Id { get; }
        public int Beneficio { get; }
        public int Peso { get; }
        public int Quantidade { get; }

        public int QuantidadeMaximaMochila { get; set; }
        public Double FuncaoObjetiva => (((Double)this.Beneficio / (Double)this.Peso)) * 100;

        // Default comparer for Part type.
        public int CompareTo(object obj)
        {
            var item = obj as Objeto;
            // A null value means that this object is greater.
            if (item == null)
                return 1;

            else
            {
                if (this.Id > item.Id)
                {
                    return 1;
                }
                else
                {
                    return -1;
                }
            }
        }

        public Objeto Clone()
        {
            return new Objeto(this, this.Quantidade);
        }

        public void MostrarObjeto()
        {
            Console.WriteLine($"ID: {this.Id} Quantidade: {this.Quantidade} Beneficio: {this.Beneficio} Peso: {this.Peso} FuncaoObjetiva: {this.FuncaoObjetiva}");
        }
    }
}


using AlgoritmoMochila.Entidade;
using System;
using System.Collections.Generic;

namespace AlgoritmoMochila
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Iniciando geracao de Mochilas");

            Program p = new Program();
            p.Inicializa();

            Console.ReadKey();
        }

        private List<Objeto> Objetos { get; set; }
        private Mochila Mochila { get; set; }
        private Mochila MochilaPai { get; set; }
        private Mochila MochilaMae { get; set; }
        private GerarMochila gerarMochila;

        public Program()
        {
            this.Mochila = new Mochila(30);


            this.Objetos = new List<Objeto>();
            this.Objetos.Add(new Objeto(1, 3, 5).CalcularQuantidadeMaximaMochila(this.Mochila));
            this.Objetos.Add(new Objeto(2, 3, 4).CalcularQuantidadeMaximaMochila(this.Mochila));
            this.Objetos.Add(new Objeto(3, 2, 7).CalcularQuantidadeMaximaMochila(this.Mochila));
            this.Objetos.Add(new Objeto(4, 4, 8).CalcularQuantidadeMaximaMochila(this.Mochila));
            this.Objetos.Add(new Objeto(5, 2, 4).CalcularQuantidadeMaximaMochila(this.Mochila));
            this.Objetos.Add(new Objeto(6, 3, 4).CalcularQuantidadeMaximaMochila(this.Mochila));
            this.Objetos.Add(new Objeto(7, 5, 6).CalcularQuantidadeMaximaMochila(this.Mochila));
            this.Objetos.Add(new Objeto(8, 2, 8).CalcularQuantidadeMaximaMochila(this.Mochila));


            this.gerarMochila = new GerarMochila(this.Objetos, this.Mochila);

        }




        public void Inicializa()
        {
            this.MochilaPai = this.gerarMochila.GerarPopulacaoInicial();
            MochilaPai.MostrarMochila();
            Console.WriteLine("===================================================\n");

            this.MochilaMae = this.gerarMochila.GerarPopulacaoInicial();
            MochilaMae.MostrarMochila();
        }

    }
}

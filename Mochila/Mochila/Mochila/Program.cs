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
        private List<Mochila> MochilaPopulacao { get; set; }
        private GerarMochila gerarMochila;

        public Program()
        {
            this.Mochila = new Mochila(25);


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
            this.MochilaPopulacao = new List<Mochila>();
        }




        public void Inicializa()
        {
            Mochila filho = this.gerarMochila.GerarPopulacaoInicial();
            this.MochilaPopulacao.Add(filho);
            filho.MostrarMochila();
            Console.WriteLine("===================================================\n");

            filho = this.gerarMochila.GerarPopulacaoInicial();
            this.MochilaPopulacao.Add(filho);
            filho.MostrarMochila();
            Console.WriteLine("===================================================\n");

            filho = this.gerarMochila.GerarPopulacaoInicial();
            this.MochilaPopulacao.Add(filho);
            filho.MostrarMochila();
            Console.WriteLine("===================================================\n");

            filho = this.gerarMochila.GerarPopulacaoInicial();
            this.MochilaPopulacao.Add(filho);
            filho.MostrarMochila();
            Console.WriteLine("===================================================\n");

        }

    }
}

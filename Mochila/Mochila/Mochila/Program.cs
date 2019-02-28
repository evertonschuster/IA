using AlgoritmoMochila.Entidade;
using AlgoritmoMochila.Genetica;
using System;
using System.Collections.Generic;

namespace AlgoritmoMochila
{
    public class Program
    {
        static void Main(string[] args)
        {
            try
            {

                Console.WriteLine("Iniciando geracao de Mochilas");

                Program p = new Program();
                p.Inicializa();

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine(e.StackTrace);
            }

        }

        private List<Objeto> Objetos { get; set; }
        private Mochila Mochila { get; set; }
        private List<Mochila> MochilaPopulacao { get; set; }
        private GerarMochila gerarMochila;
        private Geracao Geracoes;

        public Program()
        {
            this.Mochila = new Mochila(25);


            this.Objetos = new List<Objeto>();
            this.Objetos.Add(new Objeto(1, 3, 5));
            this.Objetos.Add(new Objeto(2, 3, 4));
            this.Objetos.Add(new Objeto(3, 2, 7));
            this.Objetos.Add(new Objeto(4, 4, 8));
            this.Objetos.Add(new Objeto(5, 2, 4));
            this.Objetos.Add(new Objeto(6, 3, 4));
            this.Objetos.Add(new Objeto(7, 5, 6));
            this.Objetos.Add(new Objeto(8, 2, 8));


            this.gerarMochila = new GerarMochila(this.Objetos, this.Mochila);
            this.MochilaPopulacao = new List<Mochila>();

            this.Geracoes = new Geracao(20, 100, 100,10);
        }




        public void Inicializa()
        {
            Mochila filho = this.gerarMochila.GerarPopulacaoInicial();
            this.MochilaPopulacao.Add(filho);
            filho.MostrarMochila();
            Console.WriteLine("===================================================\n");
            var filhoB = filho;

            filho = this.gerarMochila.GerarPopulacaoInicial();
            this.MochilaPopulacao.Add(filho);
            filho.MostrarMochila();
            Console.WriteLine("==================================================\n");

            filho = this.gerarMochila.GerarPopulacaoInicial();
            this.MochilaPopulacao.Add(filho);
            filho.MostrarMochila();
            Console.WriteLine("===================================================\n");
             

            filho = this.gerarMochila.GerarPopulacaoInicial();
            this.MochilaPopulacao.Add(filho);
            filho.MostrarMochila();
            Console.WriteLine("===================================================\n");
            Console.WriteLine("Iniciar");
            Console.ReadLine();


            
            this.Geracoes.AdicionarMochila(this.MochilaPopulacao);
            this.Geracoes.EvoluirPopulacao();


            Console.WriteLine("===================================================\n");
            Console.WriteLine("Finalizou");

            this.Geracoes.MelhorMochila.MostrarMochila();
            Console.WriteLine($"Geracao da Mochila : {this.Geracoes.GeracaoMelhorMochila }");
        }

    }
}

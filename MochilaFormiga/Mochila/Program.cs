using AlgoritmoMochila.Entidade;
using AlgoritmoMochila.Genetica;
using System;
using System.Collections.Generic;
using System.Linq;
using UFRJ.EngSoft23.Modelos;


//quando gerar filho deficiente, muta ele, ou repara

namespace AlgoritmoMochila
{
    public class Program
    {
        static void Main(string[] args)
        {
            try
            {

                Console.WriteLine("Iniciando Formigueiro de Mochilas");

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
        private Grafo Grafo { get; set; }
        private Formiga formiga;

        public Program()
        {
            this.Mochila = new Mochila(25);
            this.Grafo = new Grafo();

            var objeto1 = new Objeto(1, 3, 5);
            var objeto2 = new Objeto(2, 3, 4);

            this.Objetos = new List<Objeto>();
            this.Objetos.Add(objeto1);
            this.Objetos.Add(objeto2);
            this.Objetos.Add(new Objeto(3, 2, 7));
            this.Objetos.Add(new Objeto(4, 4, 8));
            this.Objetos.Add(new Objeto(5, 2, 4));
            this.Objetos.Add(new Objeto(6, 3, 4));
            this.Objetos.Add(new Objeto(7, 5, 6));
            this.Objetos.Add(new Objeto(8, 2, 8));

            foreach (var itemOrigem in this.Objetos)
            {
                foreach (var itemDestino in this.Objetos)
                {
                    this.Grafo.AddRota(itemOrigem, itemDestino);
                }
            }

            this.formiga = new Formiga(this.Grafo, objeto1,this.Mochila,3,20);

        }




        public void Inicializa()
        {
            this.formiga.Caminhar();


            Console.WriteLine("===================================================\n");
            Console.WriteLine("Finalizou");

            this.formiga.MochilaMaster.MostrarMochila();
            Console.WriteLine($"Ciclo da melhor mochila: {this.formiga.CicloMochilaMaster}");

            Console.ReadKey();
        }

    }
}

using CarteiroFormiga.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CarteiroFormiga.Iteracaoes
{

    class Caminhar
    {
        private int QuantidadeInteracao = 0;
        private Random r = new Random();
        private List<List<Rota>> RotasFeitas = new List<List<Rota>>();

        public Caminhar(int quantidadeInteracao)
        {
            QuantidadeInteracao = quantidadeInteracao;
        }

        public void GerarIteracao()
        {
            for (int i = 0; i < QuantidadeInteracao; i++)
            {

                foreach (var cidade in Cidade.GetCidade())
                {
                    var formiga = new Formiga(cidade);
                    var caminho = formiga.Caminhar();

                    this.RotasFeitas.Add(caminho);
                    Cidade.ResetRotas();
                }

                this.MostrarRotasFormigas();
                this.AddFeromonioCaminhos();
                Rota.EvaporarFeromonio();
            }

            MostrarMelhorRota();
            MostrarFeromonioRotas();
        }

        public void MostrarRotasFormigas()
        {
            foreach (var item in this.RotasFeitas)
            {
                Console.WriteLine("================================");
                Console.WriteLine($"Rota feita, Distancia Total: {item.Sum(r => r.Distancia)}");
                Console.WriteLine("================================");
                foreach (var rota in item)
                {
                    Console.WriteLine($"Cidade: {rota.CidadeA.Id } => {rota.CidadeB.Id}. Distancia: {rota.Distancia} Feromonio: {rota.Feromonio}");
                }
            }
        }

        private void AddFeromonioCaminhos()
        {
            foreach (var item in this.RotasFeitas)
            {
                foreach (var rota in item)
                {
                    Rota.AddFeromonio(rota);
                }
            }
        }

        private void MostrarMelhorRota()
        {
            var listRota = this.RotasFeitas.OrderBy(r => r.Sum(i => i.Distancia)).ToList().FirstOrDefault();
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("Possivel melhor Rota");
            Console.WriteLine($"Distancia Total: {listRota.Sum(r => r.Distancia)}");
            foreach (var rota in listRota)
            {
                Console.WriteLine($"Cidade: {rota.CidadeA.Id } => {rota.CidadeB.Id}. Distancia: {rota.Distancia} Feromonio: {rota.Feromonio}");
            }
        }

        private void MostrarFeromonioRotas()
        {
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("=====================================");
            Console.WriteLine("Nivel de Feromonio nas rotas");

            foreach (var rota in Rota.GetRota())
            {
                Console.WriteLine($"Cidade: {rota.CidadeA.Id } => {rota.CidadeB.Id}. Distancia: {rota.Distancia} Feromonio: {rota.Feromonio}");
            }
        }
    }
}

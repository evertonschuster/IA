using AlgoritmoMochila.Uteis.exception;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UFRJ.EngSoft23.Modelos;

namespace AlgoritmoMochila.Entidade
{
    public class Formiga
    {
        public Grafo Rotas { get; set; }
        public List<Aresta> CaminhoFormigueiro { get; set; }
        public Objeto ObjetoAtual { get; set; }
        public Mochila Mochila { get; set; }
        public Mochila MochilaMaster { get; set; }
        public int CicloMochilaMaster { get; set; }
    public int QuatidadeFormiga { get; set; }
        public int QuatidadeCiclosMaximo { get; set; }
        private Random r = new Random();

        public Formiga(Grafo rotas, Objeto objetoOrigem, Mochila mochila, int quatidadeFormiga, int quatidadeCiclosMaximo)
        {
            this.Rotas = rotas ?? throw new ArgumentNullException(nameof(rotas));
            this.ObjetoAtual = objetoOrigem ?? throw new ArgumentNullException(nameof(objetoOrigem));
            this.Mochila = mochila.Clone() ?? throw new ArgumentNullException(nameof(mochila));
            this.MochilaMaster = mochila.Clone() ?? throw new ArgumentNullException(nameof(mochila));
            this.QuatidadeFormiga = quatidadeFormiga;
            this.QuatidadeCiclosMaximo = quatidadeCiclosMaximo;

            this.CaminhoFormigueiro = new List<Aresta>();
        }

        public void Caminhar()
        {
            List<Aresta> Caminho = new List<Aresta>();

            for (int ciclo = 0; ciclo  < 300; ciclo++)
            {
                for (int i = 0; i < this.QuatidadeFormiga; i++)
                {

                    try
                    {
                        while (!this.Mochila.IsCheia)
                        {
                            var destino = this.EscolherRota();
                            destino.Quantidade = 1;
                            this.Mochila.AdicionarItemMochila(destino.Clone());

                            Caminho.Add(this.Rotas.Arestas.Where(a => a.Origem.Id == this.ObjetoAtual.Id && a.Destino.Id == destino.Id).FirstOrDefault());

                            //this.Caminho
                            this.ObjetoAtual = destino;
                        }
                    }
                    catch (CapacidadeMochilaException e)
                    {

                    }
                    catch (Exception e)
                    {

                    }

                    ////mostra na tela
                    this.Mochila.MostrarMochila();
                    //Caminho.ForEach(c => c.MostrarAresta());

                    //verefica a melhor mochila
                    if (this.MochilaMaster.FuncaoObjetiva < this.Mochila.FuncaoObjetiva)
                    {
                        this.MochilaMaster = this.Mochila;
                        CicloMochilaMaster = ciclo;
                    }

                    //guardas as informacoes, e limpeza das variaveis
                    Caminho.ForEach(c => this.CaminhoFormigueiro.Add(c));
                    this.Rotas.LimparCaminho();
                    Caminho.Clear();
                    this.Mochila = this.Mochila.Clone();

                    
                }


                this.Rotas.AddFeromonioCaminho(this.CaminhoFormigueiro);
                Console.WriteLine("");
                Console.WriteLine("");
                Console.WriteLine("");
                Console.WriteLine("");
                Console.WriteLine("");
                Console.WriteLine("");
                Console.WriteLine("");
                Console.WriteLine("");
                Console.WriteLine("");
                Console.WriteLine("");
                Console.WriteLine("=====================================================================================");
                Console.WriteLine("");

                this.MochilaMaster.MostrarMochila();
                this.Rotas.Arestas.ForEach(a => a.MostrarAresta());

                if (this.CicloMochilaMaster + this.QuatidadeCiclosMaximo < ciclo)
                {
                    break;
                }
            }
        }

        public Objeto EscolherRota()
        {
            //pega todas as rotas que sao possiveis do no atual
            List<Aresta> rotasPossiveis = this.Rotas.GetRotasDestinoPorcentagem(this.ObjetoAtual);

            var roleta = new Dictionary<Objeto, Double>();
            double valorAnterior = 0;

            foreach (var item in rotasPossiveis)
            {
                valorAnterior += item.PesoPorcentagem;
                roleta.Add(item.Destino, valorAnterior);
            }

            return SelecionarRota(roleta);
        }

        private Objeto SelecionarRota(Dictionary<Objeto, double> probabilidade)
        {
            var ponto = r.NextDouble() + r.Next(101);
            double valorAnterior = 0;
            Objeto chave = null;
            foreach (var item in probabilidade)
            {
                if (ponto >= valorAnterior && ponto <= item.Value)
                {
                    chave = item.Key;
                    break;
                }

                valorAnterior = item.Value;

            }

            return chave;
        }

    }
}

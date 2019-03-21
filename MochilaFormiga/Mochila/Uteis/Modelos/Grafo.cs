using AlgoritmoMochila.Entidade;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UFRJ.EngSoft23.Modelos
{
    public class Grafo
    {
        private Double QUANTIDADE_FEROMONIO = 15.8;
        private Double QUANTIDADE_EVAPORA = 15.7999999999999999;
        public List<Objeto> Vertices;
        public List<Aresta> Arestas;
        public Grafo(List<Objeto> vertices, List<Aresta> arestas)
        {
            Arestas = arestas;
            Vertices = vertices;
        }

        public List<Aresta> GetRotasDestino(Objeto objetoAtual)
        {
            var destinosPossiveis = this.Arestas.Where(a => a.Origem.Id == objetoAtual.Id).ToList();//pega todos os caminhos
            return destinosPossiveis.Where(a => a.Destino.Quantidade == 0).ToList();

        }

        public void AddFeromonioCaminho(List<Aresta> Caminho)
        {
            //var objetosMochila = this.Vertices.Where(o => o.Quantidade != 0).ToList();
            //var arestasAAdicionarFeromonio = new List<Aresta>();

            foreach (var no in Caminho)
            {

                var aresta = this.Arestas.Where(a => a.Origem.Id == no.Origem.Id && a.Destino.Id == no.Destino.Id).FirstOrDefault();
                if (aresta != null)
                {
                    aresta.Feromonio += this.QUANTIDADE_FEROMONIO;
                }

                aresta = this.Arestas.Where(a => a.Origem.Id == no.Destino.Id  && a.Destino.Id == no.Origem.Id).FirstOrDefault(); 
                if (aresta != null)
                {
                    aresta.Feromonio += this.QUANTIDADE_FEROMONIO;
                }

            }

            foreach (var item in this.Arestas)
            {
                item.Feromonio -= this.QUANTIDADE_EVAPORA;

                if(item.Feromonio < 0)
                {
                    item.Feromonio = 0;
                }
            }

        }

        public List<Aresta> GetRotasDestinoPorcentagem(Objeto objetoAtual)
        {
            var destinosPossiveis = GetRotasDestino(objetoAtual);//pega todos os caminhos
            var pesoToal = destinosPossiveis.Sum(d => d.Peso);

            foreach (var item in destinosPossiveis)
            {
                item.PesoPorcentagem = (item.Peso / pesoToal) * 100;
            }

            return destinosPossiveis;

        }

        internal void LimparCaminho()
        {
            foreach (var item in Vertices)
            {
                item.Quantidade = 0;
            }
        }

        public Grafo()
        {
            Arestas = new List<Aresta>();
            Vertices = new List<Objeto>();
        }

        public Boolean AddRota(Objeto origem, Objeto destino)
        {
            if (origem.Id == destino.Id)
            {
                return false;
            }

            if (!this.Vertices.Exists(o => o.Id == origem.Id))
            {
                this.Vertices.Add(origem);
            }


            if (!this.Arestas.Exists(a => a.Origem.Id == origem.Id && a.Destino.Id == destino.Id))
            {
                var aresta = new Aresta(origem, destino);
                this.Arestas.Add(aresta);
            }
            else
            {
                return false;
            }

            return true;
        }

        public void MostrarGrafo()
        {
            foreach (var item in Arestas)
            {
                Console.WriteLine(item.ToString());
            }
        }
    }
}

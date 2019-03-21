using CarteiroFormiga.Iteracaoes;
using CarteiroFormiga.Uteis.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CarteiroFormiga.Entidades
{
    class Formiga
    {
        public Cidade CidadeNascenca { get; set; }
        public Cidade CidadeAtual { get; set; }
        public List<Rota> RotasPassadas { get; set; }

        private Iterecao Iterecao = new Iterecao();
        private Random r = new Random();

        public Formiga(Cidade cidadeNascenca)
        {
            this.CidadeNascenca = cidadeNascenca ?? throw new ArgumentNullException(nameof(cidadeNascenca));
            this.CidadeAtual = this.CidadeNascenca;

            this.RotasPassadas = new List<Rota>();
            this.CidadeAtual.IsVisitado = true;
        }

        private void AddRota(Rota rota)
        {
            if (this.RotasPassadas.Exists(r => r.Equal(rota)))
            {
                throw new RotaRepetidaException(rota);
            }
            this.RotasPassadas.Add(rota);
        }

        public List<Rota> Caminhar()
        {
            while (!Cidade.HasAllVisitadas())
            {
                var rota = this.EscolherRota();
                this.AddRota(rota);

            }

            return this.RotasPassadas;
        }

        private Rota EscolherRota()
        {
            var rotas = Rota.GetRota(this.CidadeAtual);
            var probabilidade = new Dictionary<string, double>();

            foreach (var item in Rota.GetRota(this.CidadeAtual))
            {
                Cidade cidadeDestino = item.CidadeA;
                if (this.CidadeAtual.Id == item.CidadeA.Id)
                {
                    cidadeDestino = item.CidadeB;
                }

                var probabilidadeRota = this.Iterecao.Porcentagem(this.CidadeAtual, cidadeDestino);
                probabilidade.Add(cidadeDestino.Id, probabilidadeRota);
            }

            probabilidade = probabilidade.OrderBy(c => c.Value).ToDictionary(k => k.Key, k => k.Value);

            var formaPizza = new Dictionary<string, double>();
            double valorAnterior = 0;

            foreach (var item in probabilidade)
            {
                valorAnterior += item.Value;
                formaPizza.Add(item.Key, valorAnterior);
            }


            var chaveSelecionada = this.SelecionarRota(formaPizza);
            var cidadeEscolhida = Cidade.GetCidadeById(chaveSelecionada);

            var rota = Rota.GetRota(CidadeAtual, cidadeEscolhida);
            this.CidadeAtual = cidadeEscolhida;
            this.CidadeAtual.IsVisitado = true;
            return rota;

        }

        private string SelecionarRota(Dictionary<string, double> probabilidade)
        {
            var ponto = r.NextDouble() + r.Next(101);
            double valorAnterior = 0;
            string chave = "";
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
